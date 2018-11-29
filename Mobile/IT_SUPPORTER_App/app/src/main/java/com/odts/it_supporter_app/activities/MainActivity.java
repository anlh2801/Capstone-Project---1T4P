package com.odts.it_supporter_app.activities;

import android.app.AlertDialog;
import android.app.FragmentTransaction;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Build;
import android.support.annotation.NonNull;
import android.support.design.widget.BottomNavigationView;
import android.support.design.widget.NavigationView;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;

import com.odts.it_supporter_app.R;

import android.widget.CompoundButton;
import android.widget.ImageButton;
import android.widget.Switch;
import android.widget.TextView;

import com.odts.it_supporter_app.services.ITSupporterService;
import com.odts.it_supporter_app.utils.CallBackData;

import java.io.File;

public class MainActivity extends AppCompatActivity {

    Integer itSupporterId;
    SharedPreferences share;
    Switch swStatus;
    SharedPreferences sp;
    ITSupporterService itSupporterService;
    android.support.v7.widget.Toolbar toolbar;
    DrawerLayout mDrawerLayout;
    boolean isOnline;
    ActionBarDrawerToggle toggle;
    //    BottomNavigationView bottomNavigationView;
    ImageButton btnLogout;
    TextView username;
    NavigationView navigationView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        mDrawerLayout = findViewById(R.id.drawer_layout);
        swStatus = (Switch) findViewById(R.id.switch2);
        navigationView = findViewById(R.id.nav_view);
        View headerLayout = navigationView.inflateHeaderView(R.layout.nav_header);
//        panel = headerLayout.findViewById(R.id.viewId);
        username = (TextView) headerLayout.findViewById(R.id.username);
        share = getSharedPreferences("ODTS", Context.MODE_PRIVATE);
        itSupporterId = share.getInt("itSupporterId", 0);
        username.setText(share.getString("itName", ""));

        isOnline = true;
        initHome();
        initDrawer();
        Bundle extras = getIntent().getExtras();
        onNewIntent(getIntent());
        toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        toggle = new ActionBarDrawerToggle(MainActivity.this, mDrawerLayout, 0, 0);
        mDrawerLayout.addDrawerListener(toggle);
        toggle.syncState();
        itSupporterService.getIsOnline(this, itSupporterId, new CallBackData<Boolean>() {
            @Override
            public void onSuccess(Boolean aBoolean) {
                if (aBoolean) {
                    swStatus.setChecked(aBoolean);
//                    toolbar.setTitle("Trực tuyến");
                } else {
                    swStatus.setChecked(false);
//                    toolbar.setTitle("Ngoại tuyến");
                }

            }

            @Override
            public void onFail(String message) {

            }
        });
        swStatus.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton compoundButton, final boolean b) {
                if (!b) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.this);
                    builder.setCancelable(false);
                    builder
                            .setMessage("Bạn có muốn offline?")
                            .setPositiveButton("Có", new DialogInterface.OnClickListener() {
                                @Override
                                public void onClick(DialogInterface dialog, int id) {
                                    itSupporterService.updateStatusIT(MainActivity.this, itSupporterId, b);
//                                    toolbar.setTitle("Ngoại tuyến");
                                }
                            })
                            .setNegativeButton("Không", new DialogInterface.OnClickListener() {
                                @Override
                                public void onClick(DialogInterface dialog, int id) {
                                    dialog.cancel();
                                    swStatus.setChecked(true);
                                }
                            })
                            .show();

                } else
//                    toolbar.setTitle("Trực tuyến");
                    itSupporterService.updateStatusIT(MainActivity.this, itSupporterId, b);

            }
        });
//        btnLogout = (ImageButton) findViewById(R.id.btnLogout);
//        btnLogout.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View view) {
////                share = getSharedPreferences("ODTS", Context.MODE_PRIVATE);
//                SharedPreferences.Editor editor = share.edit();
//                editor.clear();
//                editor.commit();
//                sp = getSharedPreferences("loginHero", Context.MODE_PRIVATE);
//                SharedPreferences.Editor editor2 = sp.edit();
//                editor2.clear();
//                editor2.commit();
//                Intent intent = new Intent(MainActivity.this, LoginActivity.class);
//                startActivity(intent);
////                deleteCache(MainActivity.this);
//                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.KITKAT) {
//                    ((ActivityManager) getSystemService(Context.ACTIVITY_SERVICE))
//                            .clearApplicationUserData();
//                }
//            }
//        });
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case android.R.id.home:
                mDrawerLayout.openDrawer(GravityCompat.START);
                return true;
        }
        return super.onOptionsItemSelected(item);
    }

    private void initHome() {
        itSupporterService = new ITSupporterService();
        itSupporterService.getIsBusy(MainActivity.this, itSupporterId, new CallBackData<Boolean>() {
            @Override
            public void onSuccess(Boolean aBoolean) {
                if (!aBoolean) {
                    loadFragment(new RecieveRequestFragment());
                    toolbar.setTitle("Chờ công việc");
                } else {
                    Intent myIntent = getIntent();
                    if (myIntent.getStringExtra("scan") != null) {
                        loadFragment(new ScanDeviceFragment());
                    } else
                        toolbar.setTitle("Đang thực hiện");
                    loadFragment(new HeroFragment());
                }
            }

            @Override
            public void onFail(String message) {

            }
        });
    }

    private void initDrawer() {
        navigationView.setNavigationItemSelectedListener(new NavigationView.OnNavigationItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(MenuItem menuItem) {
                menuItem.setChecked(true);
                switch (menuItem.getItemId()) {
                    case R.id.navigation_home:
                        initHome();
                        toolbar.setTitle("Trang chủ");
                        break;
                    case R.id.navigation_scanQR:
                        loadFragment(new ScanDeviceFragment());
                        toolbar.setTitle("Tra cứu");
                        break;
                    case R.id.navigation_sumary:
                        toolbar.setTitle("Lịch sử");
                        loadFragment(new SumaryFragment());
                        break;
                    case R.id.navigation_accountDetail:
                        toolbar.setTitle("Tài khoản");
                        loadFragment(new ProfleFragment());
                        break;
                }
                mDrawerLayout.closeDrawer(GravityCompat.START);
                return true;
            }
        });

    }


    public static void deleteCache(Context context) {
        try {
            File dir = context.getCacheDir();
            if (dir != null && dir.isDirectory()) {
                deleteDir(dir);
            }
        } catch (Exception e) {
        }
    }

    public static boolean deleteDir(File dir) {
        if (dir != null && dir.isDirectory()) {
            String[] children = dir.list();
            for (int i = 0; i < children.length; i++) {
                boolean success = deleteDir(new File(dir, children[i]));
                if (!success) {
                    return false;
                }
            }
        }
        return dir.delete();
    }

    private boolean loadFragment(Fragment fragment) {
        //switching fragment
        if (fragment != null) {
//            fragment.onResume();
            getSupportFragmentManager()
                    .beginTransaction()
                    .setCustomAnimations(R.animator.enter_from_right, R.animator.exit_to_left, R.animator.enter_from_left, R.animator.exit_to_right)
                    .replace(R.id.fmHome, fragment)
                    .commit();
//            fragment.onPause();
            return true;
        }
        return false;
    }


//    @Override
//    protected void onNewIntent(Intent intent) {
//        super.onNewIntent(intent);
//        Bundle extras = intent.getExtras();
//        if (extras != null) {
//            share = getSharedPreferences("firebaseData", MODE_PRIVATE);
//            SharedPreferences.Editor editor = share.edit();
//            editor.putString("a",extras.getString("AgencyName"));
//            editor.putString("b",extras.getString("AgencyAddress"));
//            editor.putString("c",extras.getString("TicketsInfo"));
//            editor.putString("d",extras.getString("RequestName"));
//            editor.putString("e",extras.getString("RequestId"));
//            editor.commit();
//        }
//    }
}

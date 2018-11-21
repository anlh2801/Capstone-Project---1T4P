package com.odts.it_supporter_app.activities;

import android.app.ActivityManager;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Build;
import android.support.annotation.NonNull;
import android.support.design.widget.BottomNavigationView;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.CompoundButton;
import android.widget.ImageButton;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.Toolbar;

import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.customTools.BottomNavigationViewHelper;
import com.odts.it_supporter_app.models.Request;
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
    boolean isOnline;
    BottomNavigationView bottomNavigationView;
    ImageButton btnLogout;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        share = getSharedPreferences("ODTS", Context.MODE_PRIVATE);
        itSupporterId = share.getInt("itSupporterId", 0);
        isOnline = true;
        initHome();
        initBottomMenu();

//        btnChat = findViewById(R.id.btnChatMain);
//        btnChat.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View view) {
//                Intent intent = new Intent(MainActivity.this, ChatActivity.class);
//                startActivity(intent);
//            }
//        });
//        btnTimeline = findViewById(R.id.btnTimeLine);
//        btnTimeline.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View view) {
//                Intent intent = new Intent(MainActivity.this, StatusTimelineActivity.class);
//                startActivity(intent);
//            }
//        });
        Bundle extras = getIntent().getExtras();
        onNewIntent(getIntent());
        toolbar = findViewById(R.id.toolbar);
        itSupporterService.getIsOnline(this, itSupporterId, new CallBackData<Boolean>() {
            @Override
            public void onSuccess(Boolean aBoolean) {
                swStatus.setChecked(aBoolean);
            }

            @Override
            public void onFail(String message) {

            }
        });
        swStatus = (Switch) findViewById(R.id.switch2);

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
                                    toolbar.setTitle("Ngoại tuyến");
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
                    toolbar.setTitle("Trực tuyến");
                itSupporterService.updateStatusIT(MainActivity.this, itSupporterId, b);

            }
        });
        btnLogout = (ImageButton) findViewById(R.id.btnLogout);
        btnLogout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
//                share = getSharedPreferences("ODTS", Context.MODE_PRIVATE);
                SharedPreferences.Editor editor = share.edit();
                editor.clear();
                editor.commit();
                sp = getSharedPreferences("loginHero", Context.MODE_PRIVATE);
                SharedPreferences.Editor editor2 = sp.edit();
                editor2.clear();
                editor2.commit();
                Intent intent = new Intent(MainActivity.this, LoginActivity.class);
                startActivity(intent);
//                deleteCache(MainActivity.this);
                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.KITKAT) {
                    ((ActivityManager) getSystemService(Context.ACTIVITY_SERVICE))
                            .clearApplicationUserData();
                }
            }
        });
    }

    private void initHome() {
        itSupporterService = new ITSupporterService();
        itSupporterService.getIsBusy(MainActivity.this, itSupporterId, new CallBackData<Boolean>() {
            @Override
            public void onSuccess(Boolean aBoolean) {
                if (!aBoolean) {
                    loadFragment(new RecieveRequestFragment());
                } else {
                    loadFragment(new DoRequestFragment());
                }
            }

            @Override
            public void onFail(String message) {

            }
        });
    }

    private void initBottomMenu() {
        bottomNavigationView = findViewById(R.id.navigationView);
        BottomNavigationViewHelper.disableShiftMode(bottomNavigationView);
        Fragment fragment = null;
        bottomNavigationView.setOnNavigationItemSelectedListener(new BottomNavigationView.OnNavigationItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                switch (item.getItemId()) {
                    case R.id.navigation_home:
                        initHome();
                        break;
                    case R.id.navigation_scanQR:
                        loadFragment(new ScanDeviceFragment());
                        break;
                    case R.id.navigation_sumary:
                        loadFragment(new SumaryFragment());
                        break;
                    case R.id.navigation_accountDetail:
                        loadFragment(new ProfleFragment());
                        break;
                }
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

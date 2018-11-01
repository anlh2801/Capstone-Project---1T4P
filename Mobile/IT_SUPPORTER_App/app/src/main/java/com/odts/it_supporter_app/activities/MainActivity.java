package com.odts.it_supporter_app.activities;

import android.app.ActivityManager;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Build;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.google.firebase.messaging.FirebaseMessaging;
import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.models.Request;

import java.io.File;

public class MainActivity extends AppCompatActivity {

    Fragment fragment;
    SharedPreferences share;
    SharedPreferences sp;
    Button btnLogout;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        loadFragment(new RecieveRequestFragment());

        Bundle extras=  getIntent().getExtras();
        onNewIntent(getIntent());
        btnLogout = (Button) findViewById(R.id.btn_logout);
        btnLogout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                share = getSharedPreferences("ODTS", Context.MODE_PRIVATE);
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


    public static void deleteCache(Context context) {
        try {
            File dir = context.getCacheDir();
            if (dir != null && dir.isDirectory()) {
                deleteDir(dir);
            }
        } catch (Exception e) {}
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

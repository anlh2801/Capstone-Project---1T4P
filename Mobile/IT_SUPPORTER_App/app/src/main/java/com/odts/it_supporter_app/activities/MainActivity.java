package com.odts.it_supporter_app.activities;

import android.content.Intent;
import android.content.SharedPreferences;
import android.support.v4.app.Fragment;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.Button;
import android.widget.TextView;

import com.google.firebase.messaging.FirebaseMessaging;
import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.models.Request;

public class MainActivity extends AppCompatActivity {

    Fragment fragment;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        loadFragment(new RecieveRequestFragment());
        //onNewIntent(getIntent());
    }

    private boolean loadFragment(Fragment fragment) {
        //switching fragment
        if (fragment != null) {
            fragment.onResume();
            getSupportFragmentManager()
                    .beginTransaction()
                    .replace(R.id.fmHome, fragment)
                    .commit();
            fragment.onPause();
            return true;
        }
        return false;
    }

    @Override
    protected void onNewIntent(Intent intent) {
        super.onNewIntent(intent);
        Bundle extras = intent.getExtras();
        if (extras != null) {
            setContentView(R.layout.activity_main);
            if (fragment instanceof RecieveRequestFragment) {
                RecieveRequestFragment my = (RecieveRequestFragment) fragment;
                // Pass intent or its data to the fragment's method
                my.initData(extras.getString("AgencyName"),
                        extras.getString("AgencyAddress"),
                        extras.getString("TicketsInfo"),
                        extras.getString("RequestName"),
                        extras.getString("RequestId"));
            }

        }
        // Check if the fragment is an instance of the right fragment


    }
}

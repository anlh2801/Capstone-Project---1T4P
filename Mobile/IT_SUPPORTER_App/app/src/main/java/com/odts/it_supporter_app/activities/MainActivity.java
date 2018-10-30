package com.odts.it_supporter_app.activities;

import android.content.Intent;
import android.content.SharedPreferences;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.google.firebase.messaging.FirebaseMessaging;
import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.models.Request;

public class MainActivity extends AppCompatActivity {

    Fragment fragment;
    SharedPreferences share;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        loadFragment(new RecieveRequestFragment());

        Bundle extras=  getIntent().getExtras();
        onNewIntent(getIntent());
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

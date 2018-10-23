package com.odts.activities;

import android.support.v4.app.Fragment;
import android.app.FragmentManager;
import android.app.FragmentTransaction;
import android.content.Intent;
import android.content.SharedPreferences;
import android.support.annotation.NonNull;
import android.support.design.widget.BottomNavigationView;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.odts.customTools.ServiceItemAdapter;
import com.odts.models.ServiceITSupport;
import com.odts.models.ServiceItem;
import com.odts.services.ServiceITSupportService;
import com.odts.services.ServiceItemService;
import com.odts.utils.CallBackData;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    private BottomNavigationView bottomNavigationView;

    private ServiceITSupportService _serviceITSupportService;
    private ServiceItemService _serviceItem;

    FragmentManager fragmentManager = getFragmentManager();
    FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
    
    public  MainActivity(){
        _serviceITSupportService = new ServiceITSupportService();
        _serviceItem = new ServiceItemService();
    }
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        initBottomMenu ();
        loadFragment(new HomeFragment());
        SharedPreferences share = getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        Integer agencyId = share.getInt("agencyId", 0);


    }

    private boolean loadFragment(Fragment fragment) {
        //switching fragment
        if (fragment != null) {
            fragment.onResume();
            getSupportFragmentManager()
                    .beginTransaction()
                    .replace(R.id.fmHome, fragment)
                    .commit();
            fragment.onStop();
            return true;
        }
        return false;
    }

    private void initBottomMenu () {
        bottomNavigationView = findViewById(R.id.navigationView);
        Fragment fragment = null;
        bottomNavigationView.setOnNavigationItemSelectedListener(new BottomNavigationView.OnNavigationItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                switch (item.getItemId()){
                    case  R.id.navigation_home:
                        loadFragment(new HomeFragment());
                        break;
                    case  R.id.navigation_request:
                        Toast.makeText(MainActivity.this, "bc nek", Toast.LENGTH_SHORT).show();
                        break;
                    case  R.id.navigation_devices:
                        loadFragment(new ManageDeviceFragment());
                        break;
                    case  R.id.navigation_accountDetail:
                        Toast.makeText(MainActivity.this, "tai khoan nek", Toast.LENGTH_SHORT).show();
                        break;
                }
                return true;
            }
        });
    }

}

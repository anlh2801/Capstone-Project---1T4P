package com.odts.activities;

import android.app.FragmentManager;
import android.app.FragmentTransaction;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.design.widget.BottomNavigationView;
import android.support.v4.app.Fragment;
import android.support.v7.app.AppCompatActivity;
import android.view.MenuItem;

public class MainActivity extends AppCompatActivity {

    private BottomNavigationView bottomNavigationView;

    FragmentManager fragmentManager = getFragmentManager();
    FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        initBottomMenu ();
        loadFragment(new RequestFragment());
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
                        loadFragment(new RequestFragment());
                        break;
                    case  R.id.navigation_devices:
                        loadFragment(new ManageDeviceFragment());
                        break;
                    case  R.id.navigation_accountDetail:
//                        loadFragment(new ProfileFragment());
                        break;
                }
                return true;
            }
        });
    }

}

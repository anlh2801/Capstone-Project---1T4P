package com.odts.activities;

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

    private ServiceITSupportService _serviceITSupportService;
    private ServiceItemService _serviceItem;
    private TextView textView;


    public  MainActivity(){
        _serviceITSupportService = new ServiceITSupportService();
        _serviceItem = new ServiceItemService();
    }
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        SharedPreferences share = getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        Integer agencyId = share.getInt("agencyId", 0);
        getAllITSupportForAgency(3);

        BottomNavigationView bottomNavigationView = findViewById(R.id.navigationView);
        bottomNavigationView.setOnNavigationItemSelectedListener(new BottomNavigationView.OnNavigationItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                switch (item.getItemId()){
                    case  R.id.navigation_home:
                        Toast.makeText(MainActivity.this, "home nek", Toast.LENGTH_SHORT).show();
                        break;
                    case  R.id.navigation_request:
                        Toast.makeText(MainActivity.this, "bc nek", Toast.LENGTH_SHORT).show();
                        break;
                    case  R.id.navigation_devices:
                        Toast.makeText(MainActivity.this, "devie nek", Toast.LENGTH_SHORT).show();
                        break;
                    case  R.id.navigation_accountDetail:
                        Toast.makeText(MainActivity.this, "tai khoan nek", Toast.LENGTH_SHORT).show();
                        break;
                }
                return true;
            }
        });
    }

    private void getAllITSupportForAgency (int agencyId){
        LinearLayout layout = (LinearLayout) findViewById(R.id.layout_ServicesHome);
        _serviceITSupportService.getAllServiceITSupport(MainActivity.this, agencyId, new CallBackData<ArrayList<ServiceITSupport>>() {
            @Override
            public void onSuccess(ArrayList<ServiceITSupport> serviceITSupports) {
                LinearLayout layout = (LinearLayout) findViewById(R.id.layout_ServicesHome);
                // Load ServiceItem của Service đầu tiên
                getAllServiceItemByServiceId(serviceITSupports.get(0).getServiceITSupportId());
                for (ServiceITSupport item : serviceITSupports) {
                    Button bt = new Button(MainActivity.this);
                    bt.setText(item.getServiceName());
                    final int serviceId = item.getServiceITSupportId();
                    bt.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View view) {
                            getAllServiceItemByServiceId(serviceId);
                        }
                    });
                    layout.addView(bt);
                }
            }
            @Override
            public void onFail(String message) {

            }
        });
    }

    private void getAllServiceItemByServiceId (int serviceId){
        _serviceItem.getAllServiceItemByServiceId(MainActivity.this, serviceId, new CallBackData<ArrayList<ServiceItem>>() {
            @Override
            public void onSuccess(ArrayList<ServiceItem> serviceItems) {
                ListView lvServiceItem = findViewById(R.id.lvServiceItem);
                ServiceItemAdapter serviceItemAdapter = new ServiceItemAdapter(MainActivity.this, R.layout.service_item_list, serviceItems);
                lvServiceItem.setAdapter(serviceItemAdapter);
            }
            @Override
            public void onFail(String message) {

            }
        });
    }
}

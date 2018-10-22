package com.odts.activities;

import android.content.Intent;
import android.content.SharedPreferences;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.odts.customTools.ServiceItemAdapter;
import com.odts.models.ServiceITSupport;
import com.odts.models.ServiceItem;
import com.odts.services.CompanyService;
import com.odts.services.ServiceITSupportService;
import com.odts.services.ServiceItemService;
import com.odts.utils.CallBackData;
import com.odts.models.Company;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {
    private CompanyService _companyService;
    private ServiceITSupportService _serviceITSupportService;
    private ServiceItemService _serviceItem;
    private TextView textView;
    Button btnAdd;

    public  MainActivity(){
        _companyService = new CompanyService();
        _serviceITSupportService = new ServiceITSupportService();
        _serviceItem = new ServiceItemService();
    }
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        //getAllCompany ();
        SharedPreferences share = getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        Integer agencyId = share.getInt("agencyId", 0);
        getAllITSupportForAgency(3);
//        btnAdd = (Button) findViewById(R.id.btnAdd);
//        btnAdd.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View view) {
//                Intent intent = new Intent(MainActivity.this, RequestActivity.class);
//                intent.putExtra("firstKeyName","FirstKeyValue");
//                startActivity(intent);
//            }
//        });
    }

    private void getAllCompany (){
        //textView = (TextView) findViewById(R.id.testID);


        _companyService.getAllCompany(MainActivity.this, new CallBackData<ArrayList<Company>>() {
            @Override
            public void onSuccess(ArrayList<Company> companies) {
                String companiesPrint = "";
                for (Company com : companies) {
                    companiesPrint = companiesPrint + com.getCompanyName() + " - " + com.getUpdateDate() + "\n";
                }
                textView.setText(companiesPrint);
            }

            @Override
            public void onFail(String message) {

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

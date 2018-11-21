package com.odts.it_supporter_app.activities;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.ListView;
import android.widget.TextView;

import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.customTools.GuidelineAdapter;
import com.odts.it_supporter_app.models.Device;
import com.odts.it_supporter_app.models.Guideline;
import com.odts.it_supporter_app.services.ITSupporterService;
import com.odts.it_supporter_app.utils.CallBackData;

import java.util.ArrayList;

public class DeviceInfoActivity extends AppCompatActivity {

    String deviceCode;
    ITSupporterService _itSupporterService;

    TextView agencyNameDeviceInfo, deviceTypeInfo, guarantyStartDateInfo, GuarantyEndDate, CreateDateDeviceInfo;
    TextView ipDeviceInfo, portDeviceInfo, accountDeviceInfo, passWordDeviceInfo, SettingDateDeviceInfo;

    public DeviceInfoActivity(){
        _itSupporterService = new ITSupporterService();
    }
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_device_info);
        deviceCode = getIntent().getStringExtra("deviceCode");

        agencyNameDeviceInfo = findViewById(R.id.AgencyNameDeviceInfo);
        deviceTypeInfo = findViewById(R.id.DeviceTypeInfo);
        guarantyStartDateInfo = findViewById(R.id.GuarantyStartDateInfo);
        agencyNameDeviceInfo = findViewById(R.id.AgencyNameDeviceInfo);
        agencyNameDeviceInfo = findViewById(R.id.AgencyNameDeviceInfo);
        agencyNameDeviceInfo = findViewById(R.id.AgencyNameDeviceInfo);
        agencyNameDeviceInfo = findViewById(R.id.AgencyNameDeviceInfo);
        agencyNameDeviceInfo = findViewById(R.id.AgencyNameDeviceInfo);
        agencyNameDeviceInfo = findViewById(R.id.AgencyNameDeviceInfo);
        agencyNameDeviceInfo = findViewById(R.id.AgencyNameDeviceInfo);

        getAllServiceITSupportForAgency(deviceCode);
    }

    private void getAllServiceITSupportForAgency(String deviceCode) {
        _itSupporterService.checkDeviceInfo(this, deviceCode, new CallBackData<Device>() {
            @Override
            public void onSuccess(Device device) {

            }

            @Override
            public void onFail(String message) {

            }
        });
    }
}

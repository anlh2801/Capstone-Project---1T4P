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

    TextView agencyNameDeviceInfo, deviceTypeInfo, guarantyStartDateInfo, guarantyEndDate, createDateDeviceInfo;
    TextView ipDeviceInfo, portDeviceInfo, accountDeviceInfo, passWordDeviceInfo, settingDateDeviceInfo;

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
        guarantyEndDate = findViewById(R.id.GuarantyEndDate);
        createDateDeviceInfo = findViewById(R.id.CreateDateDeviceInfo);
        ipDeviceInfo = findViewById(R.id.IpDeviceInfo);
        portDeviceInfo = findViewById(R.id.PortDeviceInfo);
        accountDeviceInfo = findViewById(R.id.AccountDeviceInfo);
        passWordDeviceInfo = findViewById(R.id.PassWordDeviceInfo);
        settingDateDeviceInfo = findViewById(R.id.SettingDateDeviceInfo);

        getAllServiceITSupportForAgency(deviceCode);
    }

    private void getAllServiceITSupportForAgency(final String deviceCode) {
        _itSupporterService.checkDeviceInfo(this, deviceCode, new CallBackData<Device>() {
            @Override
            public void onSuccess(Device device) {
                agencyNameDeviceInfo.setText(device.getAgencyName());
                deviceTypeInfo.setText(device.getDeviceTypeName());
                guarantyStartDateInfo.setText(device.getGuarantyStartDate());
                guarantyEndDate.setText(device.getGuarantyEndDate());
                createDateDeviceInfo.setText(device.getCreateDate());
                ipDeviceInfo.setText(device.getIp());
                portDeviceInfo.setText(device.getPort());
                accountDeviceInfo.setText(device.getDeviceAccount());
                passWordDeviceInfo.setText(device.getDevicePassword());
                settingDateDeviceInfo.setText(device.getSettingDate());
            }

            @Override
            public void onFail(String message) {

            }
        });
    }
}

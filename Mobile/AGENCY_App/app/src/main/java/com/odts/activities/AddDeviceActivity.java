package com.odts.activities;

import android.content.SharedPreferences;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import com.odts.models.Device;
import com.odts.services.AgencyService;

public class AddDeviceActivity extends AppCompatActivity {

    AgencyService agencyService;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_device);
        Button btnSave = (Button) findViewById(R.id.btnSaveDevice);
        btnSave.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                createDevice();
            }
        });
    }
    private void createDevice() {
        SharedPreferences share = getSharedPreferences("ODTS", MODE_PRIVATE);
        int agencyID = share.getInt("agencyId", 0);

        Device device = new Device();
        device.setAgencyId(agencyID);
        device.setDeviceTypeId(1);
        device.setDeviceName("demo");
        device.setDeviceCode("democode");
        device.setGuarantyStartDate("24/11/2018");
        device.setGuarantyEndDate("24/11/2018");
        device.setIp("192");
        device.setPort("80");
        device.setSettingDate("24/11/2018");
        agencyService = new AgencyService();
        agencyService.createDevice(AddDeviceActivity.this, device);
    }
}

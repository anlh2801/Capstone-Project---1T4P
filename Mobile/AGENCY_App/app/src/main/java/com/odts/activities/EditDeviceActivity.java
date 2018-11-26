package com.odts.activities;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.odts.models.Device;
import com.odts.services.AgencyService;

public class EditDeviceActivity extends AppCompatActivity {
    EditText editTextSetting, editdeviceName, editdeviceCode, editTextIp, editTextPortTT;
    int deviceId = 0;
    AgencyService agencyService;
    Button btnSave, btnCancel;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_edit_device);
        Intent intent = getIntent();
        editdeviceCode = (EditText) findViewById(R.id.editTextDeviceCode);
        editdeviceName = (EditText) findViewById(R.id.editTextDeviceName);
        editTextIp = (EditText) findViewById(R.id.editTextIp);
        editTextPortTT = (EditText) findViewById(R.id.editTextPortTT);
        btnSave = (Button) findViewById(R.id.btnSaveDevice);
        btnCancel = (Button) findViewById(R.id.btnCancle);
        deviceId = intent.getIntExtra("deviceId", 0);
        editdeviceCode.setText(intent.getStringExtra("deviceCode"));
        editdeviceName.setText(intent.getStringExtra("deviceName"));
        editTextIp.setText(intent.getStringExtra("ip"));
        editTextPortTT.setText(intent.getStringExtra("port"));
        btnSave.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                updateDevice();
            }
        });
        btnCancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        });
    }

    private void updateDevice() {
        Device device = new Device();
        device.setDeviceId(deviceId);
        device.setDeviceCode(editdeviceCode.getText().toString());
        device.setDeviceName(editdeviceName.getText().toString());
        device.setIp(editTextIp.getText().toString());
        device.setPort(editTextPortTT.getText().toString());
        device.setGuarantyStartDate("24/11/2018");
        device.setGuarantyEndDate("24/11/2018");
        device.setDeviceTypeId(1);
        agencyService = new AgencyService();
        agencyService.updateDevice(EditDeviceActivity.this, device);
    }

}

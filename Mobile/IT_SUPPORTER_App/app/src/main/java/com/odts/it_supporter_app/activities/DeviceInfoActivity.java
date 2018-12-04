package com.odts.it_supporter_app.activities;

import android.content.Intent;
import android.graphics.Color;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;

import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.customTools.GuidelineAdapter;
import com.odts.it_supporter_app.models.Device;
import com.odts.it_supporter_app.models.DeviceHistory_Ticket;
import com.odts.it_supporter_app.models.Guideline;
import com.odts.it_supporter_app.models.Request;
import com.odts.it_supporter_app.services.ITSupporterService;
import com.odts.it_supporter_app.utils.CallBackData;

import java.util.ArrayList;

public class DeviceInfoActivity extends AppCompatActivity {

    String deviceCode;
    ITSupporterService _itSupporterService;

    TextView deviceNameInfo, deviceCodeInfo;
    TextView agencyNameDeviceInfo, deviceTypeInfo, guarantyStartDateInfo, guarantyEndDate, createDateDeviceInfo;
    TextView ipDeviceInfo, portDeviceInfo, accountDeviceInfo, passWordDeviceInfo, settingDateDeviceInfo, guarantyStatus;
    LinearLayout historyDevice;
    Button btnClose;

    public DeviceInfoActivity() {
        _itSupporterService = new ITSupporterService();
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_device_info);
        deviceCode = getIntent().getStringExtra("deviceCode");

        deviceNameInfo = findViewById(R.id.DeviceNameInfo);
        deviceCodeInfo = findViewById(R.id.DeviceCodeInfo);
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
        historyDevice = findViewById(R.id.HistoryDevice);
        btnClose = findViewById(R.id.btnClose);
        guarantyStatus = findViewById(R.id.GuarantyStatus);
        btnClose.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
//                finish();

//                MainActivity main = new MainActivity();
//                main.toast();
                Intent intent = new Intent(DeviceInfoActivity.this, MainActivity.class);
                intent.putExtra("scan", "123");
                startActivity(intent);
                overridePendingTransition(R.animator.slide_up, R.animator.slide_down);

            }

        });
        getAllServiceITSupportForAgency(deviceCode);
    }

    private void getAllServiceITSupportForAgency(final String deviceCode) {
        _itSupporterService.checkDeviceInfo(this, deviceCode, new CallBackData<Device>() {
            @Override
            public void onSuccess(Device device) {
                deviceNameInfo.setText(device.getDeviceName());
                deviceCodeInfo.setText("Mã thiết bị: " + device.getDeviceCode());
                guarantyStatus.setText("Trạng thái: " + device.getGuarantyStatus());
                if(device.getGuarantyStatus().equalsIgnoreCase("Còn bảo hành")) {
//                    guarantyStatus.setTextColor("#");
                }else {
                    guarantyStatus.setTextColor(Color.parseColor("#C62828"));
                }
                agencyNameDeviceInfo.setText(device.getAgencyName());
                deviceTypeInfo.setText("Loại thiết bị: " + device.getDeviceTypeName());
                guarantyStartDateInfo.setText("Kích hoạt bảo hành: " + device.getGuarantyStartDate());
                guarantyEndDate.setText("Hết hạn bảo hành: " + device.getGuarantyEndDate());
                createDateDeviceInfo.setText("Thêm vào hệ thống: " + device.getCreateDate());
                ipDeviceInfo.setText("IP: " + device.getIp());
                portDeviceInfo.setText("Port: " + device.getPort());
                accountDeviceInfo.setText("Tài khoản thiết bị: " + device.getDeviceAccount());
                passWordDeviceInfo.setText("Mật khẩu thiết bị: " + device.getDevicePassword());
                settingDateDeviceInfo.setText("Ngày cấu hình: " + device.getSettingDate());
                LayoutInflater inflater = getLayoutInflater();
                for (DeviceHistory_Ticket item : device.getTicketList()) {
                    View view = inflater.inflate(R.layout.device_history_item, null);
                    TextView txtHienTuong = (TextView) view.findViewById(R.id.txtHienTuong);
                    TextView txtNgayTao = (TextView) view.findViewById(R.id.txtNgayTao);

                    txtHienTuong.setText("Hiện tượng: " + item.getServiceItemName());
                    txtNgayTao.setText("Thời gian: " + item.getCreateDate());

                    historyDevice.addView(view);
                }
            }

            @Override
            public void onFail(String message) {

            }
        });
    }
}

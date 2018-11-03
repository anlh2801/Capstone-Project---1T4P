package com.odts.activities;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.design.widget.BottomSheetBehavior;
import android.support.design.widget.BottomSheetDialog;
import android.support.v4.content.LocalBroadcastManager;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.odts.customTools.DeviceAdapter;
import com.odts.customTools.DeviceRemoveAdapter;
import com.odts.models.Device;
import com.odts.models.Request;
import com.odts.models.Ticket;
import com.odts.services.DeviceService;
import com.odts.services.RequestService;
import com.odts.utils.CallBackData;

import java.util.ArrayList;
import java.util.List;


public class RequestActivity extends AppCompatActivity implements DeviceAdapter.ItemListener {
    int serviceItemId;
    int serviceId;
    int agencyId;

    TextView requestName;
    Button btnSave;
    ListView lvDeviceToRequest;
    DeviceRemoveAdapter deviceRemoveAdapter;


    ImageButton ibtnAddMoreDeviceInRequest;
    BottomSheetBehavior behavior;
    private BottomSheetDialog mBottomSheetDialog;
    private DeviceAdapter mAdapter;


    private  ArrayList<Device> deviceList;
    private  ArrayList<Device> deviceListToRequest = new ArrayList<>();

    private  RequestService _requestService;
    private DeviceService _deviceService;

    public  RequestActivity(){
        _requestService = new RequestService();
        _deviceService = new DeviceService();
    }
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_request);

        initData ();
        initDeviceListToRequest();
        getAllDeviceByAgencyIdAndServiceItem(agencyId, serviceId);

        btnSave = (Button) findViewById(R.id.btnSave);
        btnSave.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                createRequest();
            }
        });

        ibtnAddMoreDeviceInRequest = (ImageButton) findViewById(R.id.ibtnAddMoreDeviceInRequest);
        ibtnAddMoreDeviceInRequest.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showBottomSheetDialog();
            }
        });
        // Dùng cho bottom sheet RecyclerView
        View bottomSheet = findViewById(R.id.bottom_sheet);
        behavior = BottomSheetBehavior.from(bottomSheet);
        behavior.setBottomSheetCallback(new BottomSheetBehavior.BottomSheetCallback() {
            @Override
            public void onStateChanged(@NonNull View bottomSheet, int newState) {
                // React to state change
            }

            @Override
            public void onSlide(@NonNull View bottomSheet, float slideOffset) {
                // React to dragging events
            }
        });
        // Dùng đề Chuyển device từ bottom sheet khi dùng RecyclerView
        LocalBroadcastManager.getInstance(this).registerReceiver(mMessageReceiver,
                new IntentFilter("custom-message"));
    }
    private void initData () {
        SharedPreferences share = getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        agencyId = share.getInt("agencyId", 0);

        Intent myIntent = getIntent(); // gets the previously created intent
        serviceItemId = myIntent.getIntExtra("serviceItemId", 0);
        serviceId = myIntent.getIntExtra("serviceId", 0);

        requestName = findViewById(R.id.txtRequestName);
        requestName.setText(myIntent.getStringExtra("serviceItemName"));
    }

    private void initDeviceListToRequest() {
        lvDeviceToRequest = (ListView) findViewById(R.id.lvDeviceToRequest);
        deviceRemoveAdapter = new DeviceRemoveAdapter(RequestActivity.this, R.layout.device_remove_item_list, deviceListToRequest);
        lvDeviceToRequest.setAdapter(deviceRemoveAdapter);
        deviceRemoveAdapter.notifyDataSetChanged();
    }

    // Chuyển device từ bottom sheet khi dùng RecyclerView
    public BroadcastReceiver mMessageReceiver = new BroadcastReceiver() {
        @Override
        public void onReceive(Context context, Intent intent) {
            // Get extra data included in the Intent
            Device device = (Device) intent.getSerializableExtra("device");
            if (deviceListToRequest.contains(device)){
                Toast.makeText(RequestActivity.this,"Bạn đã thêm thiết bị này rồi" ,Toast.LENGTH_SHORT).show();
            }
            else {
                deviceListToRequest.add(device);
                deviceRemoveAdapter.notifyDataSetChanged();
            }

            if (mBottomSheetDialog != null) {
                mBottomSheetDialog.dismiss();
            }

        }
    };
    // ------------ Dùng RecyclerView - Bắt đầu -----------
    private void showBottomSheetDialog() {
        if (behavior.getState() == BottomSheetBehavior.STATE_EXPANDED) {
            behavior.setState(BottomSheetBehavior.STATE_COLLAPSED);
        }

        mBottomSheetDialog = new BottomSheetDialog(RequestActivity.this);
        View view = getLayoutInflater().inflate(R.layout.bottom_sheet_device_list, null);
        RecyclerView recyclerView = (RecyclerView) view.findViewById(R.id.rvDeviceList);
        recyclerView.setHasFixedSize(true);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));
        recyclerView.setAdapter(new DeviceAdapter(deviceList, new DeviceAdapter.ItemListener() {
            @Override
            public void onItemClick(Device item) {
                if (mBottomSheetDialog != null) {
                    mBottomSheetDialog.dismiss();
                }
            }
        }, this));

        mBottomSheetDialog.setContentView(view);
        mBottomSheetDialog.show();
        mBottomSheetDialog.setOnDismissListener(new DialogInterface.OnDismissListener() {
            @Override
            public void onDismiss(DialogInterface dialog) {
                mBottomSheetDialog = null;
            }
        });
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
    }

    @Override
    public void onItemClick(Device item) {
        behavior.setState(BottomSheetBehavior.STATE_COLLAPSED);
    }
    // ------------ Dùng RecyclerView - Kết thúc -----------

    private void getAllDeviceByAgencyIdAndServiceItem (int agencyId, int serviceId){
        LinearLayout layout = (LinearLayout) findViewById(R.id.layout_ServicesHome);
        _deviceService.getAllDeviceByAgencyIdAndServiceItem(RequestActivity.this, agencyId, serviceId, new CallBackData<ArrayList<Device>>() {
            @Override
            public void onSuccess(ArrayList<Device> devices) {
                deviceList = devices;
            }

            @Override
            public void onFail(String message) {

            }
        });
    }

    public void createRequest() {
        List listTicket = new ArrayList<Ticket>();
        for (Device item : deviceListToRequest) {
            Ticket tic = new Ticket();
            tic.setDeviceId(item.getDeviceId());
            tic.setDesciption("Thuộc agencyId: " + agencyId + " thiết bị: " + item.getDeviceName() + "Vấn đề: " + requestName.getText().toString());
            listTicket.add(tic);
        }

        Request request = new Request();
        request.setAgencyId(agencyId);
        request.setRequestCategoryId(3);
        request.setServiceItemId(serviceItemId);
        EditText txtRequestDesciption = (EditText) findViewById(R.id.txtRequestDesciption);
        request.setRequestDesciption(txtRequestDesciption.getText().toString());
        request.setRequestName(requestName.getText().toString());
        request.setTicket(listTicket);

        _requestService.createRequest(RequestActivity.this, request);
    }
}

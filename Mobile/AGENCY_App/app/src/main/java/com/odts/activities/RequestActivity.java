package com.odts.activities;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;

import android.content.IntentFilter;

import android.content.SharedPreferences;


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
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.odts.customTools.DeviceAdapter;
import com.odts.models.Device;
import com.odts.models.Request;
import com.odts.models.Ticket;
import com.odts.apiCaller.IRequestApiCaller;
import com.odts.services.DeviceService;
import com.odts.services.RequestService;
import com.odts.utils.CallBackData;
import com.odts.utils.RetrofitInstance;

import java.util.ArrayList;
import java.util.List;


public class RequestActivity extends AppCompatActivity implements DeviceAdapter.ItemListener {
    int serviceItemId;
    TextView requestName;
    EditText desciption;
    Button btnSave;

    Button btnAddMoreDevice;
    BottomSheetBehavior behavior;
    private BottomSheetDialog mBottomSheetDialog;
    private DeviceAdapter mAdapter;


    private  ArrayList<Device> deviceList;

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


        Intent myIntent = getIntent(); // gets the previously created intent
        SharedPreferences share = getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        final Integer agencyId = share.getInt("agencyId", 0);
        final int serviceItemId = myIntent.getIntExtra("serviceItemId", 0);

        IRequestApiCaller IRequestApiCaller = RetrofitInstance.getRequestService();
        btnSave = (Button) findViewById(R.id.btnSave);
        btnSave.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Ticket tic = new Ticket();
                tic.setDeviceId(3);
                tic.setDesciption("android description");
                List listTicket = new ArrayList<Ticket>();
                listTicket.add(tic);
                Request request = new Request();
                request.setAgencyId(agencyId);
                request.setRequestCategoryId(3);
                request.setServiceItemId(serviceItemId);
                request.setRequestName("android request name");
                request.setTicket(listTicket);

                _requestService.addRequest(RequestActivity.this, request);
            }
        });

        btnAddMoreDevice = (Button) findViewById(R.id.btnAddMoreDevice);

        btnAddMoreDevice.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showBottomSheetDialog();
            }
        });

//        View bottomSheet = findViewById(R.id.bottom_sheet);
//        behavior = BottomSheetBehavior.from(bottomSheet);
//        behavior.setBottomSheetCallback(new BottomSheetBehavior.BottomSheetCallback() {
//            @Override
//            public void onStateChanged(@NonNull View bottomSheet, int newState) {
//                // React to state change
//            }
//
//            @Override
//            public void onSlide(@NonNull View bottomSheet, float slideOffset) {
//                // React to dragging events
//            }
//        });

        LocalBroadcastManager.getInstance(this).registerReceiver(mMessageReceiver,
                new IntentFilter("custom-message"));
    }
    private void initData () {
        requestName = findViewById(R.id.txtRequestName);
        Intent myIntent = getIntent(); // gets the previously created intent
        serviceItemId = myIntent.getIntExtra("serviceItemId", 0);
        requestName.setText(myIntent.getStringExtra("serviceItemName"));
    }

    public BroadcastReceiver mMessageReceiver = new BroadcastReceiver() {
        @Override
        public void onReceive(Context context, Intent intent) {
            // Get extra data included in the Intent
            String ItemName = intent.getStringExtra("name");

            mBottomSheetDialog.dismiss();
            Toast.makeText(RequestActivity.this,ItemName ,Toast.LENGTH_SHORT).show();
        }
    };

    private void showBottomSheetDialog() {
        if (behavior.getState() == BottomSheetBehavior.STATE_EXPANDED) {
            behavior.setState(BottomSheetBehavior.STATE_COLLAPSED);
        }

        mBottomSheetDialog = new BottomSheetDialog(this);
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
        mAdapter.setListener(null);
    }


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


    @Override
    public void onItemClick(Device item) {
        behavior.setState(BottomSheetBehavior.STATE_COLLAPSED);
    }

//    public void addRequest(Request request) {
//        Call<Request> call = IRequestApiCaller.addUser(request);
//        call.enqueue(new Callback<Request>() {
//            @Override
//            public void onResponse(Call<Request> call, Response<Request> response) {
//                if(!response.body().isError()){
//                    Toast.makeText(RequestActivity.this, response.body().getSuccessMessage(), Toast.LENGTH_SHORT).show();
//                }
//                else
//                    Toast.makeText(RequestActivity.this, response.body().getWarningMessage(), Toast.LENGTH_SHORT).show();
//            }
//
//            @Override
//            public void onFailure(Call<Request> call, Throwable t) {
//                Log.e("ERROR: ", t.getMessage());
//            }
//        });
//    }
}

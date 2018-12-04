package com.odts.activities;

import android.Manifest;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.net.Uri;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.firebase.client.ChildEventListener;
import com.firebase.client.DataSnapshot;
import com.firebase.client.Firebase;
import com.firebase.client.FirebaseError;
import com.odts.customTools.StatusTimeLineAdapter;
import com.odts.models.TimeLine;
import com.odts.services.RequestService;
import com.odts.utils.Enums;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class StatusTimelineActivity extends AppCompatActivity {
    private RecyclerView mRecyclerView;
    private StatusTimeLineAdapter mTimeLineAdapter;
    private List<TimeLine> mDataList = new ArrayList<>();
    LinearLayout layout;
    Firebase reference1;
    private FloatingActionButton flbCall;
    private FloatingActionButton flbChat;
    private Button btnDone;
    private TextView itNamee, requestNamee, listDeviceNamee, createDateee;
    private RequestService requestService;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_status_timeline);

        mRecyclerView = (RecyclerView) findViewById(R.id.recyclerView);
        btnDone = findViewById(R.id.btnDoneTime);
        listDeviceNamee = findViewById(R.id.textView12);
        itNamee = findViewById(R.id.itName);
        requestNamee = findViewById(R.id.requestName);
        flbChat = findViewById(R.id.flbChat);
        flbCall = findViewById(R.id.flbCall);
        createDateee = findViewById(R.id.createDateTimeLine);

        requestService = new RequestService();
        final Intent intent = getIntent();
        final int requestID = intent.getIntExtra("requestID", 0);
        final String itName = intent.getStringExtra("itName");
        final String requestName = intent.getStringExtra("requestName");
        final String createDate = intent.getStringExtra("createDate");
        final ArrayList<String> listDeviceName = intent.getStringArrayListExtra("listDevice");
        StringBuilder sb = new StringBuilder();
        boolean foundOne = false;
        for (int i = 0; i < listDeviceName.size(); ++i) {
            if (foundOne) {
                sb.append(", ");
            }
            foundOne = true;
            sb.append(listDeviceName.get(i));
        }
        listDeviceNamee.setText("Thiết bị cần xử lý: " + sb.toString());
        createDateee.setText("Tạo vào: " + createDate);
        itNamee.setText(itName.toString());
        requestNamee.setText(requestName.toString());
        btnDone.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                requestService.cancelTicket(StatusTimelineActivity.this, requestID, Enums.RequestStatusEnum.Done.getIntValue());
                finish();
            }
        });
        flbChat.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(StatusTimelineActivity.this, ChatActivity.class);
                intent.putExtra("itNameChat", itName);
                startActivity(intent);
            }
        });
        final String itPhoneNumber = intent.getStringExtra("phoneNumber");;
        flbCall.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent callIntent = new Intent(Intent.ACTION_CALL);
                callIntent.setData(Uri.parse("tel: "+ itPhoneNumber));
                if (ContextCompat.checkSelfPermission(getApplicationContext(), Manifest.permission.CALL_PHONE) == PackageManager.PERMISSION_GRANTED) {
                    startActivity(callIntent);
                } else {
                    requestPermissions(new String[]{Manifest.permission.CALL_PHONE}, 1);
                }
            }
        });

        mRecyclerView.setLayoutManager(new LinearLayoutManager(this, LinearLayoutManager.VERTICAL, false));
        mRecyclerView.setHasFixedSize(true);
        Firebase.setAndroidContext(this);
        reference1 = new Firebase("https://mystatus-2e32a.firebaseio.com/status/" + requestID);
        reference1.addChildEventListener(new ChildEventListener() {
            @Override
            public void onChildAdded(DataSnapshot dataSnapshot, String s) {
                Map map = dataSnapshot.getValue(Map.class);
                String status = map.get("status").toString();
                String time = map.get("time").toString();
                String message = map.get("message").toString();
                setDataListItems(status, time, message);
                if (status.equalsIgnoreCase("Hoàn thành")) {
                    btnDone.setVisibility(View.VISIBLE);
                }
            }

            @Override
            public void onChildChanged(DataSnapshot dataSnapshot, String s) {

            }

            @Override
            public void onChildRemoved(DataSnapshot dataSnapshot) {

            }

            @Override
            public void onChildMoved(DataSnapshot dataSnapshot, String s) {

            }

            @Override
            public void onCancelled(FirebaseError firebaseError) {

            }
        });
    }

    private void setDataListItems(String status, String time, String message) {
        mDataList.add(0, new TimeLine(status, time, message));
        mTimeLineAdapter = new StatusTimeLineAdapter(mDataList);
        mRecyclerView.setAdapter(mTimeLineAdapter);
//        mRecyclerView.post(new Runnable() {
//            @Override
//            public void run() {
//                mRecyclerView.smoothScrollToPosition(mTimeLineAdapter.getItemCount());
//            }
//        });
    }

}

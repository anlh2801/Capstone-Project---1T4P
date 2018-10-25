package com.odts.activities;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.odts.models.ListRequest;
import com.odts.models.Request;
import com.odts.services.RequestService;
import com.odts.utils.CallBackData;

import java.util.ArrayList;

public class RequestDetailActivity extends AppCompatActivity {
    TextView rqName;
    RequestService requestService;
    Button btnCancel;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_request_detail);
        rqName = (TextView) findViewById(R.id.requestNameDetail);
        Intent myIntent = getIntent();
        int requestID = myIntent.getIntExtra("requestID", 0);
//        Toast.makeText(RequestDetailActivity.this,String.valueOf(requestID), Toast.LENGTH_SHORT ).show();
        requestService = new RequestService();
        requestService.requestDetail(RequestDetailActivity.this, requestID, new CallBackData<ListRequest>() {
            @Override
            public void onSuccess(final ListRequest listRequest) {
                rqName.setText(listRequest.getCreateDate());
                btnCancel = findViewById(R.id.btnCancle);
                btnCancel.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        requestService.cancelTicket(RequestDetailActivity.this, 3, 4);
                    }
                });

            }
            @Override
            public void onFail(String message) {

            }
        });
    }
}

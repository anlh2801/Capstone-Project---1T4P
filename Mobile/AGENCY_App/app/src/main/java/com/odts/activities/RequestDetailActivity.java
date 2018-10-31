package com.odts.activities;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.odts.models.ListRequest;
import com.odts.models.Orientation;
import com.odts.models.Request;
import com.odts.services.RequestService;
import com.odts.utils.CallBackData;

import java.util.ArrayList;

import butterknife.BindView;
import butterknife.ButterKnife;

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
        final int requestID = myIntent.getIntExtra("requestID", 0);
//        Toast.makeText(RequestDetailActivity.this,String.valueOf(requestID), Toast.LENGTH_SHORT ).show();
        requestService = new RequestService();
        requestService.requestDetail(RequestDetailActivity.this, requestID, new CallBackData<Request>() {
            @Override
            public void onSuccess(final Request listRequest) {
                rqName.setText(listRequest.getCreateDate());
                btnCancel = findViewById(R.id.btnCancle);
                btnCancel.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        AlertDialog.Builder builder = new AlertDialog.Builder(RequestDetailActivity.this);

                        builder
                                .setMessage("Are you sure?")
                                .setPositiveButton("Yes",  new DialogInterface.OnClickListener() {
                                    @Override
                                    public void onClick(DialogInterface dialog, int id) {
                                        requestService.cancelTicket(RequestDetailActivity.this, requestID, 4);
                                    }
                                })
                                .setNegativeButton("No", new DialogInterface.OnClickListener() {
                                    @Override
                                    public void onClick(DialogInterface dialog,int id) {
                                        dialog.cancel();
                                    }
                                })
                                .show();
                    }
                });

            }
            @Override
            public void onFail(String message) {

            }
        });

    }
}

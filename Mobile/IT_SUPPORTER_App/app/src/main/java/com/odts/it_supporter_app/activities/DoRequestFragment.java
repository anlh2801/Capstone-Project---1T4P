package com.odts.it_supporter_app.activities;

import android.Manifest;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.net.Uri;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.Fragment;
import android.support.v4.content.ContextCompat;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.models.Request;
import com.odts.it_supporter_app.services.ITSupporterService;
import com.odts.it_supporter_app.services.RequestService;
import com.odts.it_supporter_app.utils.CallBackData;
import com.odts.it_supporter_app.utils.Enums;

import java.text.DateFormat;
import java.time.LocalDateTime;
import java.time.LocalTime;
import java.util.ArrayList;
import java.util.Date;


public class DoRequestFragment extends Fragment {
    private RequestService _requestService;

    TextView txtRequestName;
    Button btnDone;
    Button btnCall;
    Button btnStart;
    FloatingActionButton flbGuidline;
    Integer itSupporterId = 0;
    Integer requestId = 0;
    RequestService requestService;
    ITSupporterService itSupporterService;
    TextView rqName;
    Integer serviceItemId = 0;
    public DoRequestFragment() {
        _requestService = new RequestService();

    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        final View v = inflater.inflate(R.layout.fragment_do_request, container, false);
        requestService = new RequestService();
        itSupporterService = new ITSupporterService();

        rqName = (TextView) v.findViewById(R.id.txtRequestName);
         SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        itSupporterId = share.getInt("itSupporterId", 0);
        requestId = share.getInt("requestId", 0);
        requestService.getRequestByRequestIdAndITSupporterId(getActivity(), requestId, itSupporterId, new CallBackData<Request>() {
            @Override
            public void onSuccess(final Request request) {
                //serviceItemId = request.getSe
                rqName.setText(request.getRequestName());
                btnCall = v.findViewById(R.id.btnCall);
                btnCall.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        Intent callIntent = new Intent(Intent.ACTION_CALL);
                        callIntent.setData(Uri.parse("tel: "+ request.getPhoneNumber()));
//                startActivity(callIntent);
                        if (ContextCompat.checkSelfPermission(getActivity().getApplicationContext(), Manifest.permission.CALL_PHONE) == PackageManager.PERMISSION_GRANTED) {
                            startActivity(callIntent);
                        } else {
                            requestPermissions(new String[]{Manifest.permission.CALL_PHONE}, 1);
                        }
                    }
                });
            }

            @Override
            public void onFail(String message) {
            }
        });
        // Inflate the layout for this fragment
//        SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
//        SharedPreferences.Editor edit = share.edit();
//        itSupporterId = share.getInt("itSupporterId", 0);
//        requestId = share.getInt("requestId", 0);
//
//        txtRequestName = v.findViewById(R.id.txtRequestName);
//        getAllServiceITSupportForAgency(requestId, itSupporterId);
        btnDone = v.findViewById(R.id.btnDone);
        btnDone.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                _requestService.updateStatusRequest(getContext(), requestId, Enums.RequestStatusEnum.Done.getIntValue());
            }
        });
        btnStart = v.findViewById(R.id.btnStart);
        btnStart.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                itSupporterService.updateStartTime(getContext(), requestId, DateFormat.getDateTimeInstance().format(new Date()));
            }
        });
        flbGuidline = (FloatingActionButton) v.findViewById(R.id.flbGuidline);
        flbGuidline.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(getContext(), GuidelineActivity.class);
                startActivity(intent);
            }
        });
        return v;
    }



}

package com.odts.it_supporter_app.activities;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.net.Uri;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.google.firebase.messaging.FirebaseMessaging;
import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.services.ITSupporterService;

import java.util.ArrayList;


public class RecieveRequestFragment extends Fragment {
    private ITSupporterService _itSupporterService;

    Integer itSupporterId = 0;
    Integer requestId = 0;

    Button btnReject;
    Button btnAccept;
    TextView txtAgencyAddressRecieveRequest;
    TextView txtAgencyNameRecieveRequest;
    TextView txtRequestNameRecieveRequest;
    TextView txtTicketInfoRecieveRequest;

    public RecieveRequestFragment() {
        _itSupporterService = new ITSupporterService();
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.fragment_recieve_request, container, false);
        btnReject = v.findViewById(R.id.btnReject);
        btnAccept = v.findViewById(R.id.btnAccept);
        txtAgencyAddressRecieveRequest = (TextView) v.findViewById(R.id.txtAgencyAddressRecieveRequest);
        txtAgencyNameRecieveRequest = (TextView) v.findViewById(R.id.txtAgencyNameRecieveRequest);
        txtRequestNameRecieveRequest = (TextView) v.findViewById(R.id.txtRequestNameRecieveRequest);
        txtTicketInfoRecieveRequest = (TextView) v.findViewById(R.id.txtTicketInfoRecieveRequest);
        // Inflate the layout for this fragment
        return v;
    }

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        //itSupporterId = share.getInt("itSupporterId", 0);
        itSupporterId = 1;

        FirebaseMessaging.getInstance().subscribeToTopic(itSupporterId.toString());

        btnAccept.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                getAllServiceITSupportForAgency(true);
            }
        });

        btnReject.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                getAllServiceITSupportForAgency(false);
            }
        });
    }

    public void initData(String agencyName, String agencyAddress, String ticketsInfo, String requestName, String requestId) {
        if (agencyName != null)
            txtAgencyNameRecieveRequest.setText(agencyName);
        if (agencyAddress != null)
            txtAgencyAddressRecieveRequest.setText(agencyAddress);
        if (ticketsInfo != null)
            txtTicketInfoRecieveRequest.setText(ticketsInfo);
        if (requestName != null)
            txtRequestNameRecieveRequest.setText(requestName);
        if (requestId != null)
            this.requestId = Integer.parseInt(requestId);
    }

    private void getAllServiceITSupportForAgency(boolean isAccept) {
        _itSupporterService.acceptRequest(getActivity(), requestId, itSupporterId, isAccept);
    }

}

package com.odts.it_supporter_app.activities;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
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
    SharedPreferences share2;

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

        SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        itSupporterId = share.getInt("itSupporterId", 0);
//        itSupporterId = 1;
        FirebaseMessaging.getInstance().subscribeToTopic(itSupporterId.toString());
        btnAccept.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());

                builder
                        .setMessage("Are you sure?")
                        .setPositiveButton("Yes",  new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int id) {
                                getAllServiceITSupportForAgency(true);
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

        btnReject.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                getAllServiceITSupportForAgency(false);
            }
        });
            share2 = getActivity().getSharedPreferences("firebaseData", Context.MODE_PRIVATE);
            txtAgencyNameRecieveRequest.setText(share2.getString("a", "").toString());
            txtAgencyAddressRecieveRequest.setText(share2.getString("b", "").toString());
            txtTicketInfoRecieveRequest.setText(share2.getString("c", "").toString());
            txtRequestNameRecieveRequest.setText(share2.getString("d", "").toString());
            this.requestId = Integer.parseInt(share2.getString("e", "0"));
        return v;
    }

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

//    public void initData(String agencyName, String agencyAddress, String ticketsInfo, String requestName, String requestId) {
//        if (agencyName != null)
//            txtAgencyNameRecieveRequest.setText(agencyName);
//        if (agencyAddress != null)
//            txtAgencyAddressRecieveRequest.setText(agencyAddress);
//        if (ticketsInfo != null)
//            txtTicketInfoRecieveRequest.setText(ticketsInfo);
//        if (requestName != null)
//            txtRequestNameRecieveRequest.setText(requestName);
//        if (requestId != null)
//            this.requestId = Integer.parseInt(requestId);
//    }

    private void getAllServiceITSupportForAgency(boolean isAccept) {
        _itSupporterService.acceptRequest(getActivity(), requestId, itSupporterId, isAccept);
        share2 = getActivity().getSharedPreferences("firebaseData", Context.MODE_PRIVATE);
        SharedPreferences.Editor editor2 = share2.edit();
        editor2.clear().commit();
        Intent restartIntent = getActivity().getPackageManager()
                .getLaunchIntentForPackage(getActivity().getPackageName());
        restartIntent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
        startActivity(restartIntent);
    }

}

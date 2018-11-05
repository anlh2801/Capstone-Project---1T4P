package com.odts.it_supporter_app.activities;

import android.content.Context;
import android.content.SharedPreferences;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.models.Request;
import com.odts.it_supporter_app.services.RequestService;
import com.odts.it_supporter_app.utils.CallBackData;
import com.odts.it_supporter_app.utils.Enums;

import java.util.ArrayList;


public class DoRequestFragment extends Fragment {
    private RequestService _requestService;

    TextView txtRequestName;
    Button btnDone;

    Integer itSupporterId = 0;
    Integer requestId = 0;

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
        View v = inflater.inflate(R.layout.fragment_do_request, container, false);
        // Inflate the layout for this fragment
        SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        itSupporterId = share.getInt("itSupporterId", 0);
        requestId = share.getInt("requestId", 0);
        txtRequestName = v.findViewById(R.id.txtRequestName);
        getAllServiceITSupportForAgency(requestId, itSupporterId);
        btnDone = v.findViewById(R.id.btnDone);
        btnDone.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                _requestService.updateStatusRequest(getContext(), requestId, Enums.RequestStatusEnum.Done.getIntValue());
            }
        });
        return v;
    }

    private void getAllServiceITSupportForAgency(int requestId, int itSupporterId) {
        _requestService.getRequestByRequestIdAndITSupporterId(getActivity(), requestId, itSupporterId, new CallBackData<Request>() {
            @Override
            public void onSuccess(Request request) {
                txtRequestName.setText(request.getRequestName());
            }

            @Override
            public void onFail(String message) {

            }
        });
    }


}

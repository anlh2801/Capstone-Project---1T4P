package com.odts.activities;

import android.content.Context;
import android.content.SharedPreferences;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.odts.customTools.PendingRequestAdapter;
import com.odts.models.ListRequest;
import com.odts.services.RequestService;
import com.odts.utils.CallBackData;
import com.odts.utils.Enums;

import java.util.ArrayList;

public class PendingFragment extends Fragment {

    private RequestService _requestService;
    private RecyclerView recyclerView;
    private PendingRequestAdapter pendingRequestAdapter;

    Integer agencyId = 0;

    public PendingFragment() {

        _requestService = new RequestService();
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View v = inflater.inflate(R.layout.fragment_pending, container, false);
        SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        agencyId = share.getInt("agencyId", 0);
        _requestService = new RequestService();
        _requestService.getRequestByStatus(getActivity(), agencyId, Enums.RequestStatusEnum.Pending.getIntValue(), new CallBackData<ArrayList<ListRequest>>() {
            @Override
            public void onSuccess(ArrayList<ListRequest> listRequests) {
                recyclerView = (RecyclerView) getActivity().findViewById(R.id.listPending);
                recyclerView.setLayoutManager(new LinearLayoutManager(getActivity()));
                pendingRequestAdapter = new PendingRequestAdapter(getActivity(), listRequests);
                recyclerView.setAdapter(pendingRequestAdapter);
            }

            @Override
            public void onFail(String message) {

            }
        });
        return v;
    }

}

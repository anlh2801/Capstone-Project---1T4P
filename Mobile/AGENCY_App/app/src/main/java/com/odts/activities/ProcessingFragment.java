package com.odts.activities;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import com.odts.customTools.PendingRequestAdapter;
import com.odts.customTools.ProcessRequestAdapter;
import com.odts.models.ListRequest;
import com.odts.models.Request;
import com.odts.services.RequestService;
import com.odts.utils.CallBackData;
import com.odts.utils.Enums;

import java.util.ArrayList;


public class ProcessingFragment extends Fragment {

    private RequestService requestService;
    private RecyclerView recyclerView;
    private ProcessRequestAdapter pendingRequestAdapter;
    Integer agencyId = 0;
    public ProcessingFragment (){

    }
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        agencyId = share.getInt("agencyId", 0);

        requestService = new RequestService();
        requestService.getRequestByStatus(getActivity(), agencyId, Enums.RequestStatusEnum.Processing.getIntValue(), new CallBackData<ArrayList<Request>>() {
            @Override
            public void onSuccess(ArrayList<Request> listRequests) {
                recyclerView = (RecyclerView) getActivity().findViewById(R.id.listpro);
                recyclerView.setLayoutManager(new LinearLayoutManager(getActivity()));
                pendingRequestAdapter = new ProcessRequestAdapter(getActivity(), listRequests);
                recyclerView.setAdapter(pendingRequestAdapter);
            }

            @Override
            public void onFail(String message) {

            }
        });

        return inflater.inflate(R.layout.fragment_processing, container, false);
    }

}

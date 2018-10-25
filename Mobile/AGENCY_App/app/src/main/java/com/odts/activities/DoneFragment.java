package com.odts.activities;

import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.odts.customTools.PendingRequestAdapter;
import com.odts.models.ListRequest;
import com.odts.models.Request;
import com.odts.services.RequestService;
import com.odts.utils.CallBackData;
import com.odts.utils.Enums;

import java.util.ArrayList;

/**
 * A simple {@link Fragment} subclass.
 * Activities that contain this fragment must implement the
 * to handle interaction events.
 * create an instance of this fragment.
 */
public class DoneFragment extends Fragment {

    private RequestService requestService;
    private RecyclerView recyclerView;
    private PendingRequestAdapter pendingRequestAdapter;

    Integer agencyId = 0;
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        agencyId = share.getInt("agencyId", 0);

        requestService = new RequestService();
        requestService.getRequestByStatus(getActivity(), agencyId, Enums.RequestStatusEnum.Done.getIntValue(), new CallBackData<ArrayList<Request>>() {
            @Override
            public void onSuccess(ArrayList<Request> listRequests) {
                recyclerView = (RecyclerView) getActivity().findViewById(R.id.listDone);
                recyclerView.setLayoutManager(new LinearLayoutManager(getActivity()));
                pendingRequestAdapter = new PendingRequestAdapter(getActivity(), listRequests);
                recyclerView.setAdapter(pendingRequestAdapter);
            }

            @Override
            public void onFail(String message) {

            }
        });

    }
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_done, container, false);
    }
}



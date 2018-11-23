package com.odts.activities;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import com.odts.customTools.PendingRequestAdapter;
import com.odts.models.RequestGroupMonth;
import com.odts.services.RequestService;
import com.odts.utils.CallBackData;
import com.odts.utils.Enums;

import java.util.ArrayList;

public class PendingFragment extends Fragment {

    private RequestService _requestService;
    private ListView listView;
    private PendingRequestAdapter pendingRequestAdapter;
    private com.melnykov.fab.FloatingActionButton btnCreate;

    Integer agencyId = 0;

    public PendingFragment() {
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(final LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        final View v = inflater.inflate(R.layout.fragment_pending, container, false);
        SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        listView = (ListView) v.findViewById(R.id.listPending);
        agencyId = share.getInt("agencyId", 0);
        _requestService = new RequestService();

        _requestService.getRequestByStatusWithMonth(getActivity(), agencyId, Enums.RequestStatusEnum.Pending.getIntValue(), new CallBackData<ArrayList<RequestGroupMonth>>() {
            @Override
            public void onSuccess(ArrayList<RequestGroupMonth> listRequestsWithMonth) {
                pendingRequestAdapter = new PendingRequestAdapter(getActivity(), R.layout.list_pending_request_group_item, listRequestsWithMonth);
                listView.setAdapter(pendingRequestAdapter);
//                btnCreate.attachToRecyclerView(recyclerView);
            }

            @Override
            public void onFail(String message) {

            }
        });
        btnCreate = (com.melnykov.fab.FloatingActionButton) v.findViewById(R.id.fab);
        btnCreate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(getContext(), AddRequestLayoutActivity.class);
                startActivity(intent);
            }
        });
        return v;
    }

}

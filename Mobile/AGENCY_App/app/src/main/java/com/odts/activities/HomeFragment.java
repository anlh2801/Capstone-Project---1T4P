package com.odts.activities;

import android.content.Context;
import android.content.SharedPreferences;
import android.net.Uri;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;

import com.odts.customTools.ServiceItemAdapter;
import com.odts.models.ServiceITSupport;
import com.odts.models.ServiceItem;
import com.odts.services.ServiceITSupportService;
import com.odts.services.ServiceItemService;
import com.odts.utils.CallBackData;

import java.util.ArrayList;

public class HomeFragment extends Fragment {

    private ServiceITSupportService _serviceITSupportService;
    private ServiceItemService _serviceItem;

    Integer agencyId = 0;

    public HomeFragment() {
        _serviceITSupportService = new ServiceITSupportService();
        _serviceItem = new ServiceItemService();
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_home, container, false);

    }

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        agencyId = share.getInt("agencyId", 0);

        getAllServiceITSupportForAgency(agencyId);
    }

    private void getAllServiceITSupportForAgency(int agencyId) {
        _serviceITSupportService.getAllServiceITSupport(getActivity(), agencyId, new CallBackData<ArrayList<ServiceITSupport>>() {
            @Override
            public void onSuccess(ArrayList<ServiceITSupport> serviceITSupports) {
                LinearLayout layout = (LinearLayout) getActivity().findViewById(R.id.layout_ServicesHome);

                // Load ServiceItem của Service đầu tiên
                getAllServiceItemByServiceId(serviceITSupports.get(0).getServiceITSupportId());
                for (ServiceITSupport item : serviceITSupports) {
                    LinearLayout.LayoutParams params = new LinearLayout.LayoutParams(
                            LinearLayout.LayoutParams.WRAP_CONTENT, LinearLayout.LayoutParams.MATCH_PARENT);
                    params.weight = 1.0f;
                    Button bt = new Button(getActivity());
                    bt.setLayoutParams(params);
                    bt.setText(item.getServiceName());
                    final int serviceId = item.getServiceITSupportId();
                    bt.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View view) {
                            getAllServiceItemByServiceId(serviceId);
                        }
                    });
                    layout.addView(bt);
                }
            }

            @Override
            public void onFail(String message) {

            }
        });
    }

    public void getAllServiceItemByServiceId(int serviceId) {
        _serviceItem.getAllServiceItemByServiceId(getActivity(), serviceId, new CallBackData<ArrayList<ServiceItem>>() {
            @Override
            public void onSuccess(ArrayList<ServiceItem> serviceItems) {
                ListView lvServiceItem = getActivity().findViewById(R.id.lvServiceItem);
                ServiceItemAdapter serviceItemAdapter = new ServiceItemAdapter(getActivity(), R.layout.service_item_list, serviceItems);
                lvServiceItem.setAdapter(serviceItemAdapter);
            }

            @Override
            public void onFail(String message) {

            }
        });
    }
}

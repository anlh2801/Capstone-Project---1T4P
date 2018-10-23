package com.odts.activities;

import android.content.Context;
import android.net.Uri;
import android.os.Bundle;
import android.support.design.widget.BottomNavigationView;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.ListView;

import com.odts.customTools.DeviceManageAdapter;
import com.odts.models.Device;
import com.odts.models.ServiceITSupport;
import com.odts.services.DeviceService;
import com.odts.services.ServiceITSupportService;
import com.odts.utils.CallBackData;

import java.util.ArrayList;


public class ManageDeviceFragment extends Fragment {
    private ServiceITSupportService _serviceITSupportService;
    private DeviceService _deviceService;

    public  ManageDeviceFragment(){
        _serviceITSupportService = new ServiceITSupportService();
        _deviceService = new DeviceService();
    }
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getAllServiceITSupportForAgency (3);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_manage_device, container, false);
    }


    private void getAllServiceITSupportForAgency (final int agencyId){
        _serviceITSupportService.getAllServiceITSupport(getActivity(), agencyId, new CallBackData<ArrayList<ServiceITSupport>>() {
            @Override
            public void onSuccess(ArrayList<ServiceITSupport> serviceITSupports) {
                LinearLayout layout = (LinearLayout) getActivity().findViewById(R.id.layout_ServicesManagerDevice);

                // Load ServiceItem của Service đầu tiên
                getAllDeviceByAgencyIdAndServiceItem( agencyId ,serviceITSupports.get(0).getServiceITSupportId());
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
                            getAllDeviceByAgencyIdAndServiceItem(agencyId, serviceId);
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

    private void getAllDeviceByAgencyIdAndServiceItem (int agencyId, int serviceId){
        _deviceService.getAllDeviceByAgencyIdAndServiceItem(getActivity(), agencyId ,serviceId, new CallBackData<ArrayList<Device>>() {
            @Override
            public void onSuccess(ArrayList<Device> devices) {
                ListView lvDeviceToManage = getActivity().findViewById(R.id.lvDeviceToManage);
                DeviceManageAdapter deviceManageAdapter = new DeviceManageAdapter(getActivity(), R.layout.device_manage_item_list, devices);
                lvDeviceToManage.setAdapter(deviceManageAdapter);
            }
            @Override
            public void onFail(String message) {

            }
        });
    }
}
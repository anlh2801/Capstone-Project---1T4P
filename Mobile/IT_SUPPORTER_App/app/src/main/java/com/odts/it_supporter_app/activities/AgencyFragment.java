package com.odts.it_supporter_app.activities;

import android.Manifest;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.graphics.Color;
import android.net.Uri;
import android.os.Bundle;
import android.app.Fragment;
import android.support.v4.app.FragmentTransaction;
import android.support.v4.content.ContextCompat;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.abdeveloper.library.MultiSelectDialog;
import com.abdeveloper.library.MultiSelectModel;
import com.getbase.floatingactionbutton.FloatingActionButton;
import com.getbase.floatingactionbutton.FloatingActionsMenu;
import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.apiCaller.DeviceAdapter;
import com.odts.it_supporter_app.models.Device;
import com.odts.it_supporter_app.models.DeviceHistory_Ticket;
import com.odts.it_supporter_app.models.Request;
import com.odts.it_supporter_app.models.Ticket;
import com.odts.it_supporter_app.services.DeviceService;
import com.odts.it_supporter_app.services.ITSupporterService;
import com.odts.it_supporter_app.services.RequestService;
import com.odts.it_supporter_app.utils.CallBackData;

import java.util.ArrayList;
import java.util.List;

/**
 * create an instance of this fragment.
 */
public class AgencyFragment extends android.support.v4.app.Fragment {

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @return A new instance of fragment AgencyFragment.
     */
    // TODO: Rename and change types and number of parameters
    Integer itSupporterId = 0;
    Integer requestId = 0;
    String serviceItemName;
    Integer serviceItemId = 0;
    RequestService requestService;
    LinearLayout historyAgency, historyDevice;
    FloatingActionButton btnCall, btnChat;
    DeviceService deviceService;
    MultiSelectDialog multiSelectDialog;
    ArrayList<Device> listTicket;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View v = inflater.inflate(R.layout.fragment_agency, container, false);
        final ImageButton addDevice = v.findViewById(R.id.addDevice);
        final TextView agencyName = v.findViewById(R.id.AgencyNameAgencyDetail);
        final TextView priority = v.findViewById(R.id.PriorityAgencyDetail);
        final TextView txtserviceItem = v.findViewById(R.id.ServiceItemAgencyDetail);
        final TextView createDate = v.findViewById(R.id.CreateDateAgencyDetail);
        final TextView txtAddressAgency = v.findViewById(R.id.AgencyAdressAgencuDetails);
        final TextView txtPhoneAgency = v.findViewById(R.id.AgencyPhoneAgencuDetails);
        final TextView numberDevice = v.findViewById(R.id.numberDevice);
        btnCall = v.findViewById(R.id.action_a);
        btnChat = v.findViewById(R.id.action_b);
        final FloatingActionsMenu menu = v.findViewById(R.id.multiple_actions);
        historyAgency = v.findViewById(R.id.HistoryAgency);
        historyDevice = v.findViewById(R.id.historyDevice);
        menu.bringToFront();
        SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        final int itSupporterId = share.getInt("itSupporterId", 0);
        requestService = new RequestService();
        deviceService = new DeviceService();
        final ArrayList<MultiSelectModel> listDevices = new ArrayList<>();
        requestService.getRequestByRequestIdAndITSupporterId(getActivity(), itSupporterId, new CallBackData<Request>() {
            @Override
            public void onSuccess(final Request request) {
                requestId = request.getRequestId();
                serviceItemId = request.getServiceItemId();
                serviceItemName = request.getServiceItemName();
                addDevice.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        deviceService.getAllDeviceByAgencyIdAndServiceItem(getActivity(), request.getAgencyId(), request.getServiceId(), new CallBackData<ArrayList<Device>>() {
                            @Override
                            public void onSuccess(ArrayList<Device> devices) {
                                for (int i = 0; i < devices.size(); i++) {
                                    listDevices.add(new MultiSelectModel(devices.get(i).getDeviceId(), devices.get(i).getDeviceName()));
                                }
                                final ArrayList<Integer> alreadyTickets = new ArrayList<>();
                                multiSelectDialog = new MultiSelectDialog()
                                        .title("Thiết bị") //setting title for dialog
                                        .titleSize(25)
                                        .positiveText("Chấp nhận")
                                        .negativeText("Hủy")
                                        .setMinSelectionLimit(0)
                                        .setMaxSelectionLimit(listDevices.size())
                                        .preSelectIDsList(alreadyTickets) //List of ids that you need to be selected
                                        .multiSelectList(listDevices) // the multi select model list with ids and name
                                        .onSubmit(new MultiSelectDialog.SubmitCallbackListener() {
                                            @Override
                                            public void onSelected(final ArrayList<Integer> selectedIds, final ArrayList<String> selectedNames, String dataString) {

                                                deviceService.addDeviceForRequest(getActivity(), requestId, selectedIds, new CallBackData<Boolean>() {
                                                    @Override
                                                    public void onSuccess(Boolean aBoolean) {

                                                    }

                                                    @Override
                                                    public void onFail(String message) {

                                                    }
                                                });
                                            }

                                            @Override
                                            public void onCancel() {

                                            }
                                        });
                                multiSelectDialog.show(getActivity().getSupportFragmentManager(), "multiSelectDialog");
                            }

                            @Override
                            public void onFail(String message) {

                            }
                        });
                    }
                });

                int numberDeviceString = request.getTicket().size();
                numberDevice.setText(String.valueOf(numberDeviceString));
                agencyName.setText("Cửa hàng: " + request.getAgencyName());
                if (request.getPriority().equalsIgnoreCase("Xử lý gấp")) {
                    priority.setText(request.getPriority());
                    priority.setTextColor(Color.parseColor("#C62828"));
                } else if (request.getPriority().equalsIgnoreCase("Cần xử lý")) {
                    priority.setText(request.getPriority());
                    priority.setTextColor(Color.parseColor("#F9A825"));
                } else {
                    priority.setText(request.getPriority());
                    priority.setTextColor(Color.parseColor("#2E7D32"));
                }
                createDate.setText("Tạo vào: " + request.getCreateDate());
                txtPhoneAgency.setText("Điện thoại: " + request.getPhoneNumber());
                txtAddressAgency.setText("Địa chỉ: " + request.getAgencyAddress());
                txtserviceItem.setText("Hiện tượng: " + serviceItemName);
                btnCall.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        menu.collapse();
                        Intent callIntent = new Intent(Intent.ACTION_CALL);
                        callIntent.setData(Uri.parse("tel: " + request.getPhoneNumber()));
                        if (ContextCompat.checkSelfPermission(getActivity().getApplicationContext(), Manifest.permission.CALL_PHONE) == PackageManager.PERMISSION_GRANTED) {
                            startActivity(callIntent);
                        } else {
                            requestPermissions(new String[]{Manifest.permission.CALL_PHONE}, 1);
                        }
                    }
                });
                btnChat.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        menu.collapse();
                        Intent intent = new Intent(getActivity(), ChatActivity.class);
                        startActivity(intent);
                    }
                });

                List<Device> listDevices = new ArrayList<>();

                for (final Ticket item : request.getTicket()) {
                    View v = getLayoutInflater().inflate(R.layout.device_item, null);
                    TextView txtDeviceName = (TextView) v.findViewById(R.id.txtDeviceName);
                    txtDeviceName.setText(item.getDeviceName());
                    ImageButton deviceDetail = (ImageButton) v.findViewById(R.id.deviceDetail);
                    deviceDetail.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View view) {
                            Intent intent = new Intent(getContext(), DeviceInfoActivity.class);
                            intent.putExtra("deviceCode", item.getDeviceCode());
                            getContext().startActivity(intent);
                            getActivity().overridePendingTransition(R.animator.slide_up, R.animator.slide_down);
                        }
                    });
                    historyDevice.addView(v);
                }
                requestService.getRequestHistoryByAgency(getActivity(), request.getAgencyId(), new CallBackData<ArrayList<Request>>() {
                    @Override
                    public void onSuccess(ArrayList<Request> requests) {
                        for (Request item : requests) {
                            View v1 = getLayoutInflater().inflate(R.layout.device_history_item, null);
                            TextView txtHienTuong = (TextView) v1.findViewById(R.id.txtHienTuong);
                            TextView txtNgayTao = (TextView) v1.findViewById(R.id.txtNgayTao);
                            txtHienTuong.setText("Hiện tượng: " + item.getRequestName());
                            txtNgayTao.setText("Đã bị sự cố ngày: " + item.getCreateDate());
                            historyAgency.addView(v1);
                        }
                    }
                    @Override
                    public void onFail(String message) {

                    }
                });
            }

            @Override
            public void onFail(String message) {

            }
        });

        return v;
    }

}

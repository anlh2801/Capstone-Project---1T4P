package com.odts.it_supporter_app.activities;

import android.Manifest;
import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.net.Uri;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.Fragment;
import android.support.v4.content.ContextCompat;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.firebase.client.Firebase;
import com.getbase.floatingactionbutton.FloatingActionsMenu;
import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.models.Request;
import com.odts.it_supporter_app.models.RequestTask;
import com.odts.it_supporter_app.services.ITSupporterService;
import com.odts.it_supporter_app.services.RequestService;
import com.odts.it_supporter_app.services.TaskService;
import com.odts.it_supporter_app.utils.CallBackData;

import java.text.DateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;


public class DoRequestFragment extends Fragment {
    private RequestService _requestService;

    com.getbase.floatingactionbutton.FloatingActionButton btnCall , btnChat , flbGuidline;
    Integer itSupporterId = 0;
    Integer requestId = 0;
    RequestService requestService;
    ITSupporterService itSupporterService;
    TextView rqName, agencyName, agencyAddress, createDate;
    String serviceItemName;
    Integer serviceItemId = 0;
    Button btnAccept, bt2, bt3, bt4, bt5;
    Firebase reference1;
    LinearLayout linearLayoutTask;
    TaskService taskService;
    CheckBox tick, tick2;

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
        final View v = inflater.inflate(R.layout.fragment_do_request, container, false);
        final FloatingActionsMenu menu = v.findViewById(R.id.multiple_actions);
        btnCall = v.findViewById(R.id.action_a);
        btnChat = v.findViewById(R.id.action_b);
        linearLayoutTask = (LinearLayout) v.findViewById(R.id.listTaskDo);
        linearLayoutTask.setOrientation(LinearLayout.VERTICAL);
        linearLayoutTask.setWeightSum(1f);
        taskService = new TaskService();
        taskService.getTaskByRequestID(getContext(), 216, new CallBackData<ArrayList<RequestTask>>() {
            @SuppressLint("ResourceType")
            @Override
            public void onSuccess(ArrayList<RequestTask> requestTasks) {
                for (final RequestTask item : requestTasks) {
                    tick = new CheckBox(getContext());
                    tick.setId(item.getRequestTaskId());
                    tick.setText(item.toString());
                    linearLayoutTask.addView(tick);
                    tick.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
                        @Override
                        public void onCheckedChanged(CompoundButton compoundButton, boolean b) {
                            if(b) {
                                taskService.updateTaskStatus(getContext(), item.getRequestTaskId(), true, new CallBackData<Boolean>() {
                                    @Override
                                    public void onSuccess(Boolean aBoolean) {
                                    }

                                    @Override
                                    public void onFail(String message) {

                                    }
                                });
                            }
                        }
                    });
                }
            }

            @Override
            public void onFail(String message) {

            }
        });

        Button addTask = v.findViewById(R.id.btnAddTaskDo);
        final EditText editTextTask =v.findViewById(R.id.etTaskDo);
        addTask.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                RequestTask requestTask = new RequestTask();
                requestTask.setRequestId(216);
                requestTask.setCreateByITSupporter(5);
                requestTask.setTaskDetail(editTextTask.getText().toString());
                taskService.createTask(getContext(), requestTask, new CallBackData<Boolean>() {
                    @Override
                    public void onSuccess(Boolean aBoolean) {
                        if(aBoolean) {
                            tick2 = new CheckBox(getContext());
                            linearLayoutTask.addView(tick2);
                            tick2.setText(editTextTask.getText().toString());
                        }
                    }

                    @Override
                    public void onFail(String message) {

                    }
                });
            }
        });
        requestService = new RequestService();
        itSupporterService = new ITSupporterService();
        rqName = (TextView) v.findViewById(R.id.txtRequestName);
        agencyName = v.findViewById(R.id.txtAgency);
        agencyAddress = v.findViewById(R.id.txtAddress);
        createDate = v.findViewById(R.id.txtCreateDate);
        SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        itSupporterId = share.getInt("itSupporterId", 0);
        requestService.getRequestByRequestIdAndITSupporterId(getActivity(), itSupporterId, new CallBackData<Request>() {
            @Override
            public void onSuccess(final Request request) {
                requestId = request.getRequestId();
                serviceItemId = request.getServiceItemId();
                serviceItemName = request.getServiceItemName();
                rqName.setText(request.getRequestName());
                agencyName.setText("Cửa hàng: " + request.getAgencyName());
                agencyAddress.setText("Địa chỉ: " + request.getAgencyAddress());
                createDate.setText("Tạo vào: " + request.getCreateDate());
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
                Firebase.setAndroidContext(getActivity());
                reference1 = new Firebase("https://mystatus-2e32a.firebaseio.com/status/" + requestId);
                final Map<String, String> map = new HashMap<String, String>();
                btnAccept = v.findViewById(R.id.button31);
                btnAccept.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        map.put("status", "Đã nhận");
                        map.put("time", DateFormat.getDateTimeInstance().format(new Date()));
                        reference1.push().setValue(map);
                    }
                });
                bt2 = v.findViewById(R.id.button32);
                bt2.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        map.put("status", "Đang di chuyển");
                        map.put("time", DateFormat.getDateTimeInstance().format(new Date()));
                        reference1.push().setValue(map);
                    }
                });
                bt3 = v.findViewById(R.id.button33);
                bt3.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        map.put("status", "Đang sửa chữa");
                        map.put("time", DateFormat.getDateTimeInstance().format(new Date()));
                        reference1.push().setValue(map);
                    }
                });
                bt4 = v.findViewById(R.id.button34);
                bt4.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        map.put("status", "Đợi linh kiện");
                        map.put("time", DateFormat.getDateTimeInstance().format(new Date()));
                        reference1.push().setValue(map);
                    }
                });

                bt5 = v.findViewById(R.id.button35);
                bt5.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        map.put("status", "Hoàn thành");
                        map.put("time", DateFormat.getDateTimeInstance().format(new Date()));
                        reference1.push().setValue(map);
                        itSupporterService.updateBusyIT(getContext(), itSupporterId);

                    }
                });
            }

            @Override
            public void onFail(String message) {
            }
        });
        flbGuidline =  v.findViewById(R.id.action_c);
        flbGuidline.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                menu.collapse();
                Intent intent = new Intent(getContext(), GuidelineActivity.class);
                intent.putExtra("serviceItemName", serviceItemName);
                intent.putExtra("serviceItemId", serviceItemId);
                intent.putExtra("requestId", requestId);
                intent.putExtra("itSupporterId", itSupporterId);
                startActivity(intent);
            }
        });
        return v;
    }


}

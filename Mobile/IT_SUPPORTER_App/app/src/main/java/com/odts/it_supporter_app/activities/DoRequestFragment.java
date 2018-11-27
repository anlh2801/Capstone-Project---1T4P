package com.odts.it_supporter_app.activities;

import android.Manifest;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentTransaction;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AlertDialog;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;

import com.firebase.client.Firebase;
import com.getbase.floatingactionbutton.FloatingActionsMenu;
import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.apiCaller.DeviceAdapter;
import com.odts.it_supporter_app.customTools.TaskAdapter;
import com.odts.it_supporter_app.models.Device;
import com.odts.it_supporter_app.models.Request;
import com.odts.it_supporter_app.models.RequestTask;
import com.odts.it_supporter_app.models.Ticket;
import com.odts.it_supporter_app.services.ITSupporterService;
import com.odts.it_supporter_app.services.RequestService;
import com.odts.it_supporter_app.services.TaskService;
import com.odts.it_supporter_app.utils.CallBackData;

import java.text.DateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import info.hoang8f.android.segmented.SegmentedGroup;


public class DoRequestFragment extends Fragment {

    com.getbase.floatingactionbutton.FloatingActionButton btnCall, btnChat, flbGuidline;
    Integer itSupporterId = 0;
    Integer requestId = 0;

    ITSupporterService itSupporterService;
    TextView rqName, agencyName, agencyAddress, createDate;
    String serviceItemName;
    Integer serviceItemId = 0;
    Button btnAccept, bt2, bt3, bt4, bt5;
    Firebase reference1;
    LinearLayout linearLayoutTask, linerTask;
    SegmentedGroup segmentedGroup;
    EditText userInputDialogEditText;
    ImageButton scan, btnAgencyDetail;

    RequestService _requestService;
    TaskService _taskService;
    CheckBox tick, tick2;
    private String m_Text = "";
    ListView listView, listViewDeviceC;
    TaskAdapter taskAdapter;
    DeviceAdapter deviceAdapter;

    public DoRequestFragment() {
        _requestService = new RequestService();
        _taskService = new TaskService();
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Intent intent = getActivity().getIntent();
        int requestID = intent.getIntExtra("requestId", 0);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        final View v = inflater.inflate(R.layout.fragment_do_request, container, false);
        final FloatingActionsMenu menu = v.findViewById(R.id.multiple_actions);

        menu.bringToFront();
        btnCall = v.findViewById(R.id.action_a);
        btnChat = v.findViewById(R.id.action_b);
        listView = (ListView) v.findViewById(R.id.listTask);
        itSupporterService = new ITSupporterService();
        rqName = (TextView) v.findViewById(R.id.txtRequestName);
        agencyName = v.findViewById(R.id.txtAgency);
        scan = v.findViewById(R.id.imageButton);
        scan.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ScanDeviceFragment scanDeviceFragment = new ScanDeviceFragment();
                FragmentTransaction transaction = getFragmentManager().beginTransaction();
                transaction.replace(R.id.fmHome, scanDeviceFragment);
                transaction.addToBackStack(null);
                transaction.commit();
            }
        });
        SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        itSupporterId = share.getInt("itSupporterId", 0);
        _requestService.getRequestByRequestIdAndITSupporterId(getActivity(), itSupporterId, new CallBackData<Request>() {
            @Override
            public void onSuccess(final Request request) {
                btnAgencyDetail = (ImageButton) v.findViewById(R.id.btnAgencyDetail);
                btnAgencyDetail.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
                        View v = getLayoutInflater().inflate(R.layout.agency_detail, null);
                        List<Device> listDevices = new ArrayList<>();
                        for (Ticket item : request.getTicket()) {
                            Device device = new Device();
                            device.setDeviceId(item.getDeviceId());
                            device.setDeviceName(item.getDeviceName());
                            listDevices.add(device);
                        }
                        listViewDeviceC = (ListView) v.findViewById(R.id.listDevice);
                        TextView agenyName = v.findViewById(R.id.name);
                        agenyName.setText(request.getAgencyName().toString());
                        TextView agenyAddress = v.findViewById(R.id.address);
                        agenyAddress.setText(request.getAgencyAddress().toString());

                        TextView createDate = v.findViewById(R.id.time);
                        createDate.setText(request.getCreateDate().toString());
                        deviceAdapter = new DeviceAdapter(getActivity(), R.layout.device_item, listDevices);
                        listViewDeviceC.setAdapter(deviceAdapter);
                        builder.setTitle("Chi tiết thông tin sự cố");
                        builder.setNegativeButton("Đóng", new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                dialog.cancel();
                            }
                        });
                        builder.setView(v);
                        final AlertDialog dialog = builder.create();
                        dialog.show();
                        dialog.getWindow().setLayout(WindowManager.LayoutParams.WRAP_CONTENT, WindowManager.LayoutParams.WRAP_CONTENT);
                    }
                });
                requestId = request.getRequestId();
                serviceItemId = request.getServiceItemId();
                serviceItemName = request.getServiceItemName();
                rqName.setText("Sự cố: " + request.getRequestName());
                agencyName.setText(request.getAgencyName());
//                agencyAddress.setText("Địa chỉ: " + request.getAgencyAddress());
//                createDate.setText("Tạo vào: " + request.getCreateDate());
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
//                btnAccept.setOnClickListener(new View.OnClickListener() {
//                    @Override
//                    public void onClick(View view) {
//                        map.put("status", "Đã nhận");
//                        map.put("time", DateFormat.getDateTimeInstance().format(new Date()));
//                        reference1.push().setValue(map);
//                    }
//                });
                bt2 = v.findViewById(R.id.button32);
                bt2.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        LayoutInflater layoutInflaterAndroid = LayoutInflater.from(getContext());
                        View mView = layoutInflaterAndroid.inflate(R.layout.user_input_dialog_box, null);
                        AlertDialog.Builder alertDialogBuilderUserInput = new AlertDialog.Builder(getContext());
                        alertDialogBuilderUserInput.setView(mView);

                        userInputDialogEditText = (EditText) mView.findViewById(R.id.userInputDialog);
                        alertDialogBuilderUserInput
                                .setCancelable(false)
                                .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                                    public void onClick(DialogInterface dialogBox, int id) {
                                        // ToDo get user input here
                                        map.put("status", "Đang di chuyển");
                                        map.put("message", userInputDialogEditText.getText().toString());
                                        map.put("time", DateFormat.getDateTimeInstance().format(new Date()));
                                        reference1.push().setValue(map);
                                    }
                                })
                                .setNegativeButton("Cancel",
                                        new DialogInterface.OnClickListener() {
                                            public void onClick(DialogInterface dialogBox, int id) {
                                                dialogBox.cancel();
                                            }
                                        });

                        AlertDialog alertDialogAndroid = alertDialogBuilderUserInput.create();
                        alertDialogAndroid.show();
                    }
                });
                bt3 = v.findViewById(R.id.button33);
                bt3.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        LayoutInflater layoutInflaterAndroid = LayoutInflater.from(getContext());
                        View mView = layoutInflaterAndroid.inflate(R.layout.user_input_dialog_box, null);
                        AlertDialog.Builder alertDialogBuilderUserInput = new AlertDialog.Builder(getContext());
                        alertDialogBuilderUserInput.setView(mView);

                        userInputDialogEditText = (EditText) mView.findViewById(R.id.userInputDialog);
                        alertDialogBuilderUserInput
                                .setCancelable(false)
                                .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                                    public void onClick(DialogInterface dialogBox, int id) {
                                        // ToDo get user input here
                                        map.put("status", "Đang sửa chữa");
                                        map.put("message", userInputDialogEditText.getText().toString());
                                        map.put("time", DateFormat.getDateTimeInstance().format(new Date()));
                                        reference1.push().setValue(map);
                                    }
                                })

                                .setNegativeButton("Cancel",
                                        new DialogInterface.OnClickListener() {
                                            public void onClick(DialogInterface dialogBox, int id) {
                                                dialogBox.cancel();
                                            }
                                        });

                        AlertDialog alertDialogAndroid = alertDialogBuilderUserInput.create();
                        alertDialogAndroid.show();
                    }
                });


                bt4 = v.findViewById(R.id.button34);
                bt4.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        LayoutInflater layoutInflaterAndroid = LayoutInflater.from(getContext());
                        View mView = layoutInflaterAndroid.inflate(R.layout.user_input_dialog_box, null);
                        AlertDialog.Builder alertDialogBuilderUserInput = new AlertDialog.Builder(getContext());
                        alertDialogBuilderUserInput.setView(mView);

                        userInputDialogEditText = (EditText) mView.findViewById(R.id.userInputDialog);
                        alertDialogBuilderUserInput
                                .setCancelable(false)
                                .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                                    public void onClick(DialogInterface dialogBox, int id) {
                                        // ToDo get user input here
                                        map.put("status", "Đợi linh kiện");
                                        map.put("message", userInputDialogEditText.getText().toString());
                                        map.put("time", DateFormat.getDateTimeInstance().format(new Date()));
                                        reference1.push().setValue(map);
                                    }
                                })

                                .setNegativeButton("Cancel",
                                        new DialogInterface.OnClickListener() {
                                            public void onClick(DialogInterface dialogBox, int id) {
                                                dialogBox.cancel();
                                            }
                                        });

                        AlertDialog alertDialogAndroid = alertDialogBuilderUserInput.create();
                        alertDialogAndroid.show();
                    }
                });

                bt5 = v.findViewById(R.id.button35);
                bt5.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        map.put("time", DateFormat.getDateTimeInstance().format(new Date()));
                        android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(getActivity());
                        builder
                                .setMessage("Bạn có chắc chắn hoàn thành công việc không?")
                                .setPositiveButton("Có", new DialogInterface.OnClickListener() {
                                    @Override
                                    public void onClick(DialogInterface dialog, int id) {
                                        itSupporterService.updateBusyIT(getContext(), itSupporterId);
                                        Intent intent = new Intent(getContext(), MainActivity.class);
                                        intent.putExtra("done", "done");
                                        startActivity(intent);
                                    }
                                })
                                .setNegativeButton("Không", new DialogInterface.OnClickListener() {
                                    @Override
                                    public void onClick(DialogInterface dialog, int id) {
                                        dialog.dismiss();
                                    }
                                })
                                .show();

                    }
                });
                _taskService.getTaskByRequestID(getContext(), requestId, new CallBackData<ArrayList<RequestTask>>() {
                    @Override
                    public void onSuccess(ArrayList<RequestTask> requestTasks) {
                        taskAdapter = new TaskAdapter(getActivity(), R.layout.task_item, requestTasks);
                        listView.setAdapter(taskAdapter);
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
        flbGuidline = v.findViewById(R.id.action_c);
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


        ImageButton addMoreTask = v.findViewById(R.id.addMoreTask);
        addMoreTask.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
                builder.setTitle("Thêm việc cần làm");

                LayoutInflater li = LayoutInflater.from(getActivity());
                final View promptsView = li.inflate(R.layout.add_more_task_form, null);
                builder.setView(promptsView);
                builder.setPositiveButton("Thêm", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        EditText a = (EditText) promptsView.findViewById(R.id.haha);
                        m_Text = a.getText().toString();

                        final RequestTask requestTask = new RequestTask();
                        requestTask.setRequestId(requestId);
                        requestTask.setCreateByITSupporter(itSupporterId);
                        requestTask.setTaskDetail(m_Text);
                        _taskService.createTask(getContext(), requestTask, new CallBackData<Boolean>() {
                            @Override
                            public void onSuccess(Boolean aBoolean) {
                                if (aBoolean) {
                                    taskAdapter.add(requestTask);
                                    taskAdapter.notifyDataSetChanged();
//                                    listView.refreshDrawableState();
//                                    listView.invalidateViews();
////                                            tick2 = new CheckBox(getContext());
////                                            linearLayoutTask.addView(tick2);
////                                            tick2.setText(m_Text);
                                }
                            }

                            @Override
                            public void onFail(String message) {

                            }
                        });
                    }
                });
                builder.setNegativeButton("Hủy", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.cancel();
                    }
                });

                builder.show();
            }
        });

        return v;
    }


}



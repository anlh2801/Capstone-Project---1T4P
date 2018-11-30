package com.odts.it_supporter_app.activities;

import android.Manifest;
import android.app.Activity;
import android.app.ActivityOptions;
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
import com.getbase.floatingactionbutton.FloatingActionButton;
import com.getbase.floatingactionbutton.FloatingActionsMenu;
import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.apiCaller.DeviceAdapter;
import com.odts.it_supporter_app.customTools.AgencyHistoryAdapter;
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


    Integer itSupporterId = 0;
    Integer requestId = 0;

    ITSupporterService itSupporterService;
    TextView rqName;
    String serviceItemName;
    Integer serviceItemId = 0;
    Button bt2, bt3, bt4, bt5;
    Firebase reference1;
    SegmentedGroup segmentedGroup;
    EditText userInputDialogEditText;
    RequestService _requestService;
    TaskService _taskService;

    private String m_Text = "";
    ListView listView;
    TaskAdapter taskAdapter;


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
        segmentedGroup = v.findViewById(R.id.segmented3);
        listView = (ListView) v.findViewById(R.id.listTask);
        itSupporterService = new ITSupporterService();
        rqName = (TextView) v.findViewById(R.id.txtRequestName);
        SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        itSupporterId = share.getInt("itSupporterId", 0);
        _requestService.getRequestByRequestIdAndITSupporterId(getActivity(), itSupporterId, new CallBackData<Request>() {
            @Override
            public void onSuccess(final Request request) {

                requestId = request.getRequestId();
                serviceItemId = request.getServiceItemId();
                serviceItemName = request.getServiceItemName();
                reference1 = new Firebase("https://mystatus-2e32a.firebaseio.com/status/" + requestId);
                final Map<String, String> map = new HashMap<String, String>();
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
//                                        segmentedGroup.removeView(bt2);
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
                                        map.put("status", "Đợi thiết bị");
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

                bt5 = v.findViewById(R.id.btnDone);
                bt5.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {

                        android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(getActivity());
                        builder
                                .setMessage("Bạn có chắc chắn hoàn thành công việc không?")
                                .setPositiveButton("Có", new DialogInterface.OnClickListener() {
                                    @Override
                                    public void onClick(DialogInterface dialog, int id) {
                                        map.put("status", "Hoàn thành");
                                        map.put("message", "");
                                        map.put("time", DateFormat.getDateTimeInstance().format(new Date()));
                                        reference1.push().setValue(map);
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
        return v;
    }
}



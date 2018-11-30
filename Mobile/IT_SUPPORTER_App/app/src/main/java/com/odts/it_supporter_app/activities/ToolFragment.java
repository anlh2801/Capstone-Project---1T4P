package com.odts.it_supporter_app.activities;

import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AlertDialog;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;

import com.firebase.client.Firebase;
import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.apiCaller.DeviceAdapter;
import com.odts.it_supporter_app.customTools.AgencyHistoryAdapter;
import com.odts.it_supporter_app.customTools.TaskAdapter;
import com.odts.it_supporter_app.models.Request;
import com.odts.it_supporter_app.models.RequestTask;
import com.odts.it_supporter_app.services.ITSupporterService;
import com.odts.it_supporter_app.services.RequestService;
import com.odts.it_supporter_app.services.TaskService;
import com.odts.it_supporter_app.utils.CallBackData;

import java.util.ArrayList;

import info.hoang8f.android.segmented.SegmentedGroup;

public class ToolFragment extends Fragment {
    Integer itSupporterId = 0;
    Integer requestId = 0;

    ITSupporterService itSupporterService;
    TextView rqName;
    String serviceItemName;
    Integer serviceItemId = 0;

    SegmentedGroup segmentedGroup;

    RequestService _requestService;
    TaskService _taskService;
    private String m_Text = "";
    ListView listView;
    TaskAdapter taskAdapter;

    public ToolFragment() {
        _requestService = new RequestService();
        _taskService = new TaskService();
    }


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View v = inflater.inflate(R.layout.fragment_tool, container, false);
        segmentedGroup = v.findViewById(R.id.segmented3);
        listView = (ListView) v.findViewById(R.id.listTask);
        itSupporterService = new ITSupporterService();
        rqName = (TextView) v.findViewById(R.id.txtRequestName);
        SharedPreferences share = getActivity().getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        itSupporterId = share.getInt("itSupporterId", 0);
        _requestService.getRequestByRequestIdAndITSupporterId(getActivity(), itSupporterId, new CallBackData<Request>() {
            @Override
            public void onSuccess(Request request) {
                requestId = request.getRequestId();
                serviceItemId = request.getServiceItemId();
                serviceItemName = request.getServiceItemName();
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
        ImageButton scan = v.findViewById(R.id.ibScan);
        scan.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ScanDeviceFragment scanDeviceFragment = new ScanDeviceFragment();
                FragmentTransaction transaction = getFragmentManager().beginTransaction();
                transaction.setCustomAnimations(R.animator.enter_from_right, R.animator.exit_to_left, R.animator.enter_from_left, R.animator.exit_to_right);
                transaction.replace(R.id.fmHome, scanDeviceFragment);
                transaction.addToBackStack(null);
                transaction.commit();
            }
        });
        android.support.design.widget.FloatingActionButton flbGuidline = v.findViewById(R.id.fabGuideline);

        flbGuidline.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(getContext(), GuidelineActivity.class);
                intent.putExtra("serviceItemName", serviceItemName);
                intent.putExtra("serviceItemId", serviceItemId);
                intent.putExtra("requestId", requestId);
                intent.putExtra("itSupporterId", itSupporterId);
                startActivity(intent);
                getActivity().overridePendingTransition(R.animator.slide_up, R.animator.slide_down);
//                startActivity(intent, ActivityOptions.makeSceneTransitionAnimation(getActivity()).toBundle());
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
                        requestTask.setTaskStatus(1);
                        _taskService.createTask(getContext(), requestTask, new CallBackData<Boolean>() {
                            @Override
                            public void onSuccess(Boolean aBoolean) {
                                if (aBoolean) {
                                    taskAdapter.add(requestTask);
                                    taskAdapter.notifyDataSetChanged();
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

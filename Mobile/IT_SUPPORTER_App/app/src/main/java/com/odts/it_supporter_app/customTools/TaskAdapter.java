package com.odts.it_supporter_app.customTools;

import android.app.Activity;
import android.content.DialogInterface;
import android.content.Intent;
import android.support.annotation.NonNull;
import android.support.v7.app.AlertDialog;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;

import com.odts.it_supporter_app.R;

import com.odts.it_supporter_app.models.RequestTask;
import com.odts.it_supporter_app.services.TaskService;
import com.odts.it_supporter_app.utils.CallBackData;

import java.util.ArrayList;
import java.util.List;

import cn.refactor.library.SmoothCheckBox;

public class TaskAdapter extends ArrayAdapter<RequestTask> {
    Activity context;
    int resource;
    List<RequestTask> objects;
    TaskService taskService;

    public TaskAdapter(@NonNull Activity context, int resource, @NonNull List<RequestTask> objects) {
        super(context, resource, objects);
        this.context = context;
        this.resource = resource;
        this.objects = objects;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater = this.context.getLayoutInflater();
        View row = inflater.inflate(this.resource, null);
        TextView txtDeviceNameManage = (TextView) row.findViewById(R.id.txtDeviceNameManage);
        final  ImageButton btnDeleteDevice = (ImageButton) row.findViewById(R.id.btnDeleteDevice);
        final SmoothCheckBox smoothCheckBox = (SmoothCheckBox) row.findViewById(R.id.cbTask);
        taskService = new TaskService();
        taskService.getTaskByRequestID(getContext(), 367, new CallBackData<ArrayList<RequestTask>>() {
            @Override
            public void onSuccess(final ArrayList<RequestTask> requestTasks) {
                for (final RequestTask item : requestTasks) {
                    smoothCheckBox.setOnCheckedChangeListener(new SmoothCheckBox.OnCheckedChangeListener() {
                        @Override
                        public void onCheckedChanged(SmoothCheckBox smoothCheckBox, boolean b) {
                            if (b) {
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
                    btnDeleteDevice.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View view) {
                            taskService.deleteTask(getContext(), item.getRequestTaskId(), new CallBackData<Boolean>() {
                                @Override
                                public void onSuccess(Boolean aBoolean) {

                                }

                                @Override
                                public void onFail(String message) {

                                }
                            });
                        }
                    });
                    
                }
            }

            @Override
            public void onFail(String message) {

            }
        });


        final RequestTask requestTask = this.objects.get(position);
        txtDeviceNameManage.setText(requestTask.getTaskDetail());

        return row;
    }

}

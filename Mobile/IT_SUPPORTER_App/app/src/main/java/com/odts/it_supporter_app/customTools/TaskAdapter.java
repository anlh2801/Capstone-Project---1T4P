package com.odts.it_supporter_app.customTools;

import android.app.Activity;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
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

import com.odts.it_supporter_app.models.Request;
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
    ImageButton btnDeleteDevice;
    SmoothCheckBox smoothCheckBox;

    public TaskAdapter(@NonNull Activity context, int resource, @NonNull List<RequestTask> objects) {
        super(context, resource, objects);
        this.context = context;
        this.resource = resource;
        this.objects = objects;
    }

    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater = this.context.getLayoutInflater();
        View row = inflater.inflate(this.resource, null);
        btnDeleteDevice = (ImageButton) row.findViewById(R.id.btnDeleteDevice);
        smoothCheckBox = (SmoothCheckBox) row.findViewById(R.id.cbTask);
        TextView txtDeviceNameManage = (TextView) row.findViewById(R.id.txtDeviceNameManage);
        taskService = new TaskService();
        final RequestTask requestTask = this.objects.get(position);
        if (requestTask.getTaskStatus() == 2) {
            smoothCheckBox.setChecked(true);
        }
        else smoothCheckBox.setChecked(false);
        smoothCheckBox.setOnCheckedChangeListener(new SmoothCheckBox.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(SmoothCheckBox smoothCheckBox, boolean b) {
                taskService.updateTaskStatus(context, requestTask.getRequestTaskId(), b, new CallBackData<Boolean>() {
                    @Override
                    public void onSuccess(Boolean aBoolean) {

                    }

                    @Override
                    public void onFail(String message) {

                    }
                });
            }


        });
        btnDeleteDevice.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                taskService.deleteTask(getContext(), requestTask.getRequestTaskId(), new CallBackData<Boolean>() {
                    @Override
                    public void onSuccess(Boolean aBoolean) {
                        if (aBoolean) {
                            objects.remove(position);
                            notifyDataSetChanged();
                        }
                    }

                    @Override
                    public void onFail(String message) {

                    }
                });
            }
        });

        txtDeviceNameManage.setText(requestTask.getTaskDetail());

        return row;
    }

}

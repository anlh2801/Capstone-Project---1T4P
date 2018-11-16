package com.odts.it_supporter_app.activities;

import android.annotation.SuppressLint;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.LinearLayout;

import com.odts.it_supporter_app.models.RequestTask;
import com.odts.it_supporter_app.services.TaskService;
import com.odts.it_supporter_app.utils.CallBackData;
import com.odts.it_supporter_app.R;

import java.util.ArrayList;

public class TaskActivity extends AppCompatActivity {
    TaskService taskService;
    CheckBox tick, tick2;
    LinearLayout linearLayouttt;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_task);
        final ArrayList<RequestTask> options = new ArrayList<>();
        linearLayouttt = (LinearLayout) findViewById(R.id.taskRequest);
        linearLayouttt.setOrientation(LinearLayout.VERTICAL);
        linearLayouttt.setWeightSum(1f);
        taskService = new TaskService();
        taskService.getTaskByRequestID(TaskActivity.this, 216, new CallBackData<ArrayList<RequestTask>>() {
            @SuppressLint("ResourceType")
            @Override
            public void onSuccess(ArrayList<RequestTask> requestTasks) {
                for (RequestTask item : requestTasks) {
//                    options.add(item);
                    tick = new CheckBox(TaskActivity.this);
                    tick.setId(item.getRequestTaskId());
                    tick.setText(item.toString());
                    linearLayouttt.addView(tick);

                }

            }

            @Override
            public void onFail(String message) {

            }
        });
        Button addTask = findViewById(R.id.btnAddTask);
        final EditText editTextTask = findViewById(R.id.txtTask);
        addTask.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                RequestTask requestTask = new RequestTask();
                requestTask.setRequestId(216);
                requestTask.setCreateByITSupporter(5);
                requestTask.setTaskDetail(editTextTask.getText().toString());
                taskService.createTask(TaskActivity.this, requestTask, new CallBackData<Boolean>() {
                    @Override
                    public void onSuccess(Boolean aBoolean) {
                        if(aBoolean) {
                            tick2 = new CheckBox(TaskActivity.this);
                            linearLayouttt.addView(tick2);
                            tick2.setText(editTextTask.getText().toString());
                        }
                    }

                    @Override
                    public void onFail(String message) {

                    }
                });
            }
        });
    }
}

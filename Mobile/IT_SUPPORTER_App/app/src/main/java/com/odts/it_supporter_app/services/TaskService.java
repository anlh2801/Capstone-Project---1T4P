package com.odts.it_supporter_app.services;

import android.content.Context;
import android.content.Intent;
import android.util.Log;
import android.widget.Toast;

import com.odts.it_supporter_app.apiCaller.ITaskApiCaller;
import com.odts.it_supporter_app.models.RequestTask;
import com.odts.it_supporter_app.utils.CallBackData;
import com.odts.it_supporter_app.utils.ResponseObject;
import com.odts.it_supporter_app.utils.ResponseObjectReturnList;
import com.odts.it_supporter_app.utils.RetrofitInstance;

import java.util.ArrayList;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class TaskService {
    public void getTaskByRequestID(final Context context, int requestID, final CallBackData<ArrayList<RequestTask>> callBackData) {
        ITaskApiCaller service = RetrofitInstance.getRetrofitInstance().create(ITaskApiCaller.class);
        Call<ResponseObjectReturnList<RequestTask>> call = service.getTaskByRequestID(requestID);
        call.enqueue(new Callback<ResponseObjectReturnList<RequestTask>>() {
            @Override
            public void onResponse(Call<ResponseObjectReturnList<RequestTask>> call, Response<ResponseObjectReturnList<RequestTask>> response) {
                if (response.code() == 200 && response.body() != null) {
                    if (!response.body().isError()) {
                        callBackData.onSuccess(response.body().getObjList());
                    }
                } else {
                    Log.e("MainActivity", "error");
                }
            }

            @Override
            public void onFailure(Call<ResponseObjectReturnList<RequestTask>> call, Throwable t) {

            }
        });

    }

    public void createTask(final Context context, RequestTask task, final CallBackData<Boolean> callBackData) {
        ITaskApiCaller service = RetrofitInstance.getRetrofitInstance().create(ITaskApiCaller.class);
        Call<ResponseObject<Boolean>> call = service.createTask(task);
        call.enqueue(new Callback<ResponseObject<Boolean>>() {
            @Override
            public void onResponse(Call<ResponseObject<Boolean>> call, Response<ResponseObject<Boolean>> response) {
                if (!response.body().isError()) {
                    Toast.makeText(context, response.body().getSuccessMessage(), Toast.LENGTH_SHORT).show();
                    if (response.body().getObjReturn() != false) {
                        callBackData.onSuccess(response.body().getObjReturn());
                    }
                }
            }

            @Override
            public void onFailure(Call<ResponseObject<Boolean>> call, Throwable t) {
                Log.e("ERROR: ", t.getMessage());
            }
        });
    }

    public void updateTaskStatus(final Context context, Integer requestTaskId, Boolean isDone, final CallBackData<Boolean> callBackData) {
        ITaskApiCaller service = RetrofitInstance.getRetrofitInstance().create(ITaskApiCaller.class);
        Call<ResponseObject<Boolean>> call = service.updateTaskStatus(requestTaskId, isDone);
        call.enqueue(new Callback<ResponseObject<Boolean>>() {
            @Override
            public void onResponse(Call<ResponseObject<Boolean>> call, Response<ResponseObject<Boolean>> response) {
                if (!response.body().isError()) {
                    Toast.makeText(context, response.body().getSuccessMessage(), Toast.LENGTH_SHORT).show();
                    if (response.body().getObjReturn() != false) {
                        callBackData.onSuccess(response.body().getObjReturn());
                    }
                }
            }

            @Override
            public void onFailure(Call<ResponseObject<Boolean>> call, Throwable t) {
                Log.e("ERROR: ", t.getMessage());
            }
        });
    }

    public void deleteTask(final Context context, Integer requestTaskId, final CallBackData<Boolean> callBackData) {
        ITaskApiCaller service = RetrofitInstance.getRetrofitInstance().create(ITaskApiCaller.class);
        Call<ResponseObject<Boolean>> call = service.deleteTask(requestTaskId);
        call.enqueue(new Callback<ResponseObject<Boolean>>() {
            @Override
            public void onResponse(Call<ResponseObject<Boolean>> call, Response<ResponseObject<Boolean>> response) {
                if (!response.body().isError()) {
                    Toast.makeText(context, response.body().getSuccessMessage(), Toast.LENGTH_SHORT).show();
                    if (response.body().getObjReturn() != false) {
                        callBackData.onSuccess(response.body().getObjReturn());
                    }
                }
            }

            @Override
            public void onFailure(Call<ResponseObject<Boolean>> call, Throwable t) {
                Log.e("ERROR: ", t.getMessage());
            }
        });
    }

    public void getStatusbyTaskID(final Context context, int requestID, final CallBackData<RequestTask> callBackData) {
        ITaskApiCaller service = RetrofitInstance.getRetrofitInstance().create(ITaskApiCaller.class);
        Call<ResponseObject<RequestTask>> call = service.getStatusbyTaskID(requestID);
        call.enqueue(new Callback<ResponseObject<RequestTask>>() {
            @Override
            public void onResponse(Call<ResponseObject<RequestTask>> call, Response<ResponseObject<RequestTask>> response) {
                if (response.code() == 200 && response.body() != null) {
                    if (!response.body().isError()) {
                        callBackData.onSuccess(response.body().getObjReturn());
                    }
                } else {
                    Log.e("MainActivity", "error");
                }
            }

            @Override
            public void onFailure(Call<ResponseObject<RequestTask>> call, Throwable t) {

            }
        });

    }
}

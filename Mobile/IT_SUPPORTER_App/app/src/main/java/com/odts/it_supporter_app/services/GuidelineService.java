package com.odts.it_supporter_app.services;

import android.content.Context;
import android.util.Log;
import android.widget.Toast;


import com.odts.it_supporter_app.apiCaller.IGuidelineApiCaller;
import com.odts.it_supporter_app.apiCaller.IRequestTaskApiCaller;
import com.odts.it_supporter_app.models.Guideline;
import com.odts.it_supporter_app.models.RequestTask;
import com.odts.it_supporter_app.utils.CallBackData;
import com.odts.it_supporter_app.utils.ResponseObject;
import com.odts.it_supporter_app.utils.ResponseObjectReturnList;
import com.odts.it_supporter_app.utils.RetrofitInstance;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Call;

public class GuidelineService {
    public void getGuidelineByServiceItemID (final Context context, int serviceItemId, final CallBackData<ArrayList<Guideline>> callBackData) {
        IGuidelineApiCaller service = RetrofitInstance.getRetrofitInstance().create(IGuidelineApiCaller.class);
        Call<ResponseObjectReturnList<Guideline>> call = service.getGuidelineByServiceItemID(serviceItemId);
        call.enqueue(new Callback<ResponseObjectReturnList<Guideline>>() {
            @Override
            public void onResponse(Call<ResponseObjectReturnList<Guideline>> call, Response<ResponseObjectReturnList<Guideline>> response) {
                if(response.code() == 200 && response.body() != null){
                    if (!response.body().isError()) {
                        callBackData.onSuccess(response.body().getObjList());
                    }
                    else {
                        Toast.makeText(context, response.body().getWarningMessage(), Toast.LENGTH_SHORT).show();
                    }

                } else {
                    Log.e("MainActivity", "error" );
                }
            }

            @Override
            public void onFailure(Call<ResponseObjectReturnList<Guideline>> call, Throwable t) {
                Toast.makeText(context, "Có lỗi", Toast.LENGTH_SHORT).show();
            }
        });
    }

    public void createTaskFromGuidline(final Context context, ArrayList<RequestTask> requestTask) {
        IRequestTaskApiCaller service = RetrofitInstance.getRetrofitInstance().create(IRequestTaskApiCaller.class);
        Call<ResponseObject<Integer>> call = service.createTaskFromGuidline(requestTask);
        call.enqueue(new Callback<ResponseObject<Integer>>() {
            @Override
            public void onResponse(Call<ResponseObject<Integer>> call, Response<ResponseObject<Integer>> response) {
                if (!response.body().isError()) {
                    Toast.makeText(context, response.body().getSuccessMessage(), Toast.LENGTH_SHORT).show();
                    if (response.body().getObjReturn() != null && response.body().getObjReturn() > 0) {
                        Toast.makeText(context, response.body().getSuccessMessage(), Toast.LENGTH_LONG);
                    }
                } else
                    Toast.makeText(context, response.body().getWarningMessage(), Toast.LENGTH_SHORT).show();
            }

            @Override
            public void onFailure(Call<ResponseObject<Integer>> call, Throwable t) {
                Log.e("ERROR: ", t.getMessage());
            }
        });
    }
}

package com.odts.services;

import android.content.Context;
import android.util.Log;
import android.widget.Toast;

import com.odts.activities.RequestActivity;
import com.odts.apiCaller.IRequestApiCaller;
import com.odts.models.Request;
import com.odts.utils.ResponseObject;
import com.odts.utils.RetrofitInstance;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class RequestService {
    IRequestApiCaller IRequestApiCaller;
    public void addRequest(final Context context, Request request) {
        IRequestApiCaller = RetrofitInstance.getRequestService();
        Call<ResponseObject<Boolean>> call = IRequestApiCaller.addUser(request);
        call.enqueue(new Callback<ResponseObject<Boolean>>() {
            @Override
            public void onResponse(Call<ResponseObject<Boolean>> call, Response<ResponseObject<Boolean>> response) {
                if(!response.body().isError()){
                    Toast.makeText(context, response.body().getSuccessMessage(), Toast.LENGTH_SHORT).show();
                }
                else
                    Toast.makeText(context, response.body().getWarningMessage(), Toast.LENGTH_SHORT).show();
            }

            @Override
            public void onFailure(Call<ResponseObject<Boolean>> call, Throwable t) {
                Log.e("ERROR: ", t.getMessage());
            }
        });
    }
}

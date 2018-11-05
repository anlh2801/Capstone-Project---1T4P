package com.odts.it_supporter_app.services;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.util.Log;
import android.widget.Toast;

import com.odts.it_supporter_app.activities.MainActivity;
import com.odts.it_supporter_app.apiCaller.ILoginApiCaller;
import com.odts.it_supporter_app.apiCaller.IRequestApiCaller;
import com.odts.it_supporter_app.models.ITSupporter;
import com.odts.it_supporter_app.models.Request;
import com.odts.it_supporter_app.utils.CallBackData;
import com.odts.it_supporter_app.utils.ResponseObject;
import com.odts.it_supporter_app.utils.RetrofitInstance;

import java.util.ArrayList;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class RequestService {
    IRequestApiCaller iRequestApiCaller;

    public void getRequestByRequestIdAndITSupporterId (final Context context, int requestId, int itSupportId, final CallBackData<Request> callBackData) {
        iRequestApiCaller = RetrofitInstance.getRequesService();

        /** Call the method with parameter in the interface to get the notice data*/
        Call<ResponseObject<Request>> call = iRequestApiCaller.getRequestByRequestIdAndITSupporterId(requestId, itSupportId);

        /**Log the URL called*/
        Log.wtf("URL Called", call.request().url() + "");

        call.enqueue(new Callback<ResponseObject<Request>>() {
            @Override
            public void onResponse(Call<ResponseObject<Request>> call, Response<ResponseObject<Request>> response) {
                if(response.code() == 200 && response.body() != null){
                    if (!response.body().isError()) {
                        callBackData.onSuccess(response.body().getObjReturn());
                    }
                    else {
                        Toast.makeText(context, response.body().getWarningMessage(), Toast.LENGTH_SHORT).show();
                    }

                } else {
                    Log.e("MainActivity", "error" );
                }
            }

            @Override
            public void onFailure(Call<ResponseObject<Request>> call, Throwable t) {
                Toast.makeText(context, "Có lỗi", Toast.LENGTH_SHORT).show();
            }
        });
    }

    public void updateStatusRequest(final Context context, int requestId, int status) {
        iRequestApiCaller = RetrofitInstance.getRequesService();
        Call<ResponseObject<Boolean>> call = iRequestApiCaller.updateStatusRequest(requestId, status);
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

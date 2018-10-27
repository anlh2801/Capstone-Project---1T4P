package com.odts.it_supporter_app.services;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.util.Log;
import android.widget.Toast;

import com.odts.it_supporter_app.activities.MainActivity;
import com.odts.it_supporter_app.apiCaller.IITSupporterApiCaller;
import com.odts.it_supporter_app.apiCaller.ILoginApiCaller;
import com.odts.it_supporter_app.models.ITSupporter;
import com.odts.it_supporter_app.utils.ResponseObject;
import com.odts.it_supporter_app.utils.RetrofitInstance;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class ITSupporterService {
    IITSupporterApiCaller iitSupporterApiCaller;
    public void checkLogin(final Context context, int requestId, int itSupporterId, boolean isAccept) {
        iitSupporterApiCaller = RetrofitInstance.getITSupporterService();
        Call<ResponseObject<Boolean>> call = iitSupporterApiCaller.acceptRequest(itSupporterId, requestId, isAccept);
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

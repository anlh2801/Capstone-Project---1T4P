package com.odts.services;

import android.content.Context;
import android.util.Log;
import android.widget.Toast;

import com.odts.apiCaller.IAgencyApiCaller;
import com.odts.apiCaller.IDeviceApiCaller;
import com.odts.models.Agency;
import com.odts.models.Device;
import com.odts.utils.CallBackData;
import com.odts.utils.ResponseObject;
import com.odts.utils.ResponseObjectReturnList;
import com.odts.utils.RetrofitInstance;

import java.util.ArrayList;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class AgencyService {
    public void getAgencyProfile(final Context context, int agencyId, final CallBackData<Agency> callBackData) {
        IAgencyApiCaller service = RetrofitInstance.getRetrofitInstance().create(IAgencyApiCaller.class);

        /** Call the method with parameter in the interface to get the notice data*/
        Call<ResponseObject<Agency>> call = service.getAgencyProfile(agencyId);

        /**Log the URL called*/
        Log.wtf("URL Called", call.request().url() + "");

        call.enqueue(new Callback<ResponseObject<Agency>>() {
            @Override
            public void onResponse(Call<ResponseObject<Agency>> call, Response<ResponseObject<Agency>> response) {
                if (response.code() == 200 && response.body() != null) {
                    if (!response.body().isError()) {
                        callBackData.onSuccess(response.body().getObjReturn());
                    }

                } else {
                    Log.e("MainActivity", "error");
                }
            }

            @Override
            public void onFailure(Call<ResponseObject<Agency>> call, Throwable t) {

            }
        });
    }
}

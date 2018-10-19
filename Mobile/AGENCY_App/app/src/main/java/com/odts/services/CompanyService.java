package com.odts.services;

import android.content.Context;
import android.util.Log;
import android.widget.Toast;

import com.odts.models.Company;
import com.odts.utils.CallBackData;
import com.odts.utils.GetNoticeDataService;
import com.odts.utils.ResponseObjectReturnList;
import com.odts.utils.RetrofitInstance;

import java.util.ArrayList;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class CompanyService {

    public void getAllCompany (final Context context, final CallBackData<ArrayList<Company>> callBackData) {
        GetNoticeDataService service = RetrofitInstance.getRetrofitInstance().create(GetNoticeDataService.class);

        /** Call the method with parameter in the interface to get the notice data*/
        Call<ResponseObjectReturnList<Company>> call = service.getCompanyData();

        /**Log the URL called*/
        Log.wtf("URL Called", call.request().url() + "");

        call.enqueue(new Callback<ResponseObjectReturnList<Company>>() {
            @Override
            public void onResponse(Call<ResponseObjectReturnList<Company>> call, Response<ResponseObjectReturnList<Company>> response) {
                if(response.code() == 200 && response.body() != null){
                     if (!response.body().isError()) {
                         callBackData.onSuccess(response.body().getObjList());
                         Toast.makeText(context, response.body().getSuccessMessage(), Toast.LENGTH_SHORT).show();
                     }
                     else {
                         Toast.makeText(context, response.body().getWarningMessage(), Toast.LENGTH_SHORT).show();
                     }

                } else {
                    Log.e("MainActivity", "error" );
                }
            }

            @Override
            public void onFailure(Call<ResponseObjectReturnList<Company>> call, Throwable t) {
                Toast.makeText(context, "Có lỗi", Toast.LENGTH_SHORT).show();
            }
        });
    }
}

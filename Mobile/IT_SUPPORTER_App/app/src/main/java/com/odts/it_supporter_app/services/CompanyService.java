package com.odts.it_supporter_app.services;

import android.content.Context;
import android.util.Log;
import android.widget.Toast;

import com.odts.it_supporter_app.models.Company;
import com.odts.it_supporter_app.models.CompanyList;
import com.odts.it_supporter_app.utils.CallBackData;
import com.odts.it_supporter_app.utils.GetNoticeDataService;
import com.odts.it_supporter_app.utils.RetrofitInstance;

import java.util.ArrayList;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class CompanyService {

    public void getAllCompany (final Context context, final CallBackData<ArrayList<Company>> callBackData) {
        final ArrayList<Company> noticeCompanyArrayList;
        GetNoticeDataService service = RetrofitInstance.getRetrofitInstance().create(GetNoticeDataService.class);

        /** Call the method with parameter in the interface to get the notice data*/
        Call<CompanyList> call = service.getCompanyData();

        /**Log the URL called*/
        Log.wtf("URL Called", call.request().url() + "");

        call.enqueue(new Callback<CompanyList>() {
            @Override
            public void onResponse(Call<CompanyList> call, Response<CompanyList> response) {
                if(response.code() == 200 && response.body() != null){
                     if (!response.body().isError()) {
                         callBackData.onSuccess(response.body().getCompanyList());
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
            public void onFailure(Call<CompanyList> call, Throwable t) {
                Toast.makeText(context, "Có lỗi", Toast.LENGTH_SHORT).show();
            }
        });
    }
}

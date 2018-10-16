package com.example.chiennt.odts_agency_mobile;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.widget.Toast;

import com.example.chiennt.odts_agency_mobile.model.CompanyList;
import com.example.chiennt.odts_agency_mobile.utils.GetNoticeDataService;
import com.example.chiennt.odts_agency_mobile.utils.RetrofitInstance;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        GetNoticeDataService service = RetrofitInstance.getRetrofitInstance().create(GetNoticeDataService.class);

        /** Call the method with parameter in the interface to get the notice data*/
        Call<CompanyList> call = service.getCompanyData();

        /**Log the URL called*/
        Log.wtf("URL Called", call.request().url() + "");

        call.enqueue(new Callback<CompanyList>() {
            @Override
            public void onResponse(Call<CompanyList> call, Response<CompanyList> response) {
//                generateNoticeList(response.body().getNoticeArrayList());
                if(response.code() == 200 && response.body() != null){
                    Log.e("MainActivity", "success"+ response.body()   );
                } else {
                    Log.e("MainActivity", "error" );
                }
            }

            @Override
            public void onFailure(Call<CompanyList> call, Throwable t) {
                Toast.makeText(MainActivity.this, "Something went wrong...Error message: " + t.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }
}

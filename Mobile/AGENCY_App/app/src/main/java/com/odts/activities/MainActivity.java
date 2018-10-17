package com.odts.activities;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.widget.TextView;
import android.widget.Toast;
import com.odts.utils.GetNoticeDataService;
import com.odts.utils.RetrofitInstance;
import com.odts.models.Company;
import com.odts.models.CompanyList;

import java.util.ArrayList;

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
                    //Log.e("MainActivity", "success"+ response.body()   );
                    ArrayList<Company> noticeCompanyArrayList = response.body().getCompanyArrayList();
                    TextView textView = (TextView) findViewById(R.id.testID);
                    String a = "";
                    for (Company com : noticeCompanyArrayList) {
                        a = a + com.getCompanyName() + " - " + com.getUpdateDate() + "\n";
                    }
                    textView.setText(a);
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

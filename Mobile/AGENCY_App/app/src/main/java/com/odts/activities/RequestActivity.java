package com.odts.activities;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;
import com.odts.models.Request;
import com.odts.models.Ticket;
import com.odts.services.RequestService;
import com.odts.utils.RetrofitInstance;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;


public class RequestActivity extends AppCompatActivity {
    RequestService requestService;
    EditText agencyId;
    EditText requestCategoryId;
    EditText serviceItemId;
    EditText requestName;
    EditText deviceId;
    EditText desciption;
    Button btnSave;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_request);
        requestService = RetrofitInstance.getRequestService();
        btnSave = (Button) findViewById(R.id.btnSave);
        btnSave.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Ticket tic = new Ticket();
                tic.setDeviceId(3);
                tic.setDesciption("android description");
                List listTicket = new ArrayList<Ticket>();
                listTicket.add(tic);
                Request request = new Request();
                request.setAgencyId(3);
                request.setRequestCategoryId(3);
                request.setServiceItemId(1);
                request.setRequestName("android request name");
                request.setTicket(listTicket);
                addRequest(request);
            }
        });
    }
    public void addRequest(Request request) {
        Call<Request> call = requestService.addUser(request);
        call.enqueue(new Callback<Request>() {
            @Override
            public void onResponse(Call<Request> call, Response<Request> response) {
                if(!response.body().isError()){
                    Toast.makeText(RequestActivity.this, response.body().getSuccessMessage(), Toast.LENGTH_SHORT).show();
                }
                else
                    Toast.makeText(RequestActivity.this, response.body().getWarningMessage(), Toast.LENGTH_SHORT).show();
            }

            @Override
            public void onFailure(Call<Request> call, Throwable t) {
                Log.e("ERROR: ", t.getMessage());
            }
        });
    }
}

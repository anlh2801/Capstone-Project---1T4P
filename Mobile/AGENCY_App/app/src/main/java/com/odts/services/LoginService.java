package com.odts.services;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.util.Log;
import android.widget.Toast;

import com.odts.activities.LoginActivity;
import com.odts.activities.MainActivity;
import com.odts.apiCaller.ILoginApiCaller;
import com.odts.models.Agency;
import com.odts.utils.ResponseObject;
import com.odts.utils.RetrofitInstance;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class LoginService {
    ILoginApiCaller iLoginApiCaller;
    public void checkLogin(final Context context, String username, String password, Integer roleId) {
        iLoginApiCaller = RetrofitInstance.getLoginService();
        Call<ResponseObject<Agency>> call = iLoginApiCaller.checkLogin(username, password, roleId);
        call.enqueue(new Callback<ResponseObject<Agency>>() {
            @Override
            public void onResponse(Call<ResponseObject<Agency>> call, Response<ResponseObject<Agency>> response) {
                if(!response.body().isError()){
                    //Toast.makeText(context, response.body().getSuccessMessage(), Toast.LENGTH_SHORT).show();
                    SharedPreferences share = context.getSharedPreferences("ODTS", 0);
                    SharedPreferences.Editor edit = share.edit();
                    edit.putInt("agencyId", response.body().getObjReturn().getAgencyId());
                    edit.commit();
                    Intent intent = new Intent(context, MainActivity.class);
                    context.startActivity(intent);
                }
                else
                    Toast.makeText(context, response.body().getWarningMessage(), Toast.LENGTH_SHORT).show();
            }
            @Override
            public void onFailure(Call<ResponseObject<Agency>> call, Throwable t) {
                Log.e("ERROR: ", t.getMessage());
            }
        });
    }
}

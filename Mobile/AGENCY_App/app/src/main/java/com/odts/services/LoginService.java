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
    SharedPreferences share, sp;
    ILoginApiCaller iLoginApiCaller;

    public void checkLogin(final Context context, String username, String password, Integer roleId) {
        iLoginApiCaller = RetrofitInstance.getLoginService();
        Call<ResponseObject<Agency>> call = iLoginApiCaller.checkLogin(username, password, roleId);
        call.enqueue(new Callback<ResponseObject<Agency>>() {
            @Override
            public void onResponse(Call<ResponseObject<Agency>> call, Response<ResponseObject<Agency>> response) {
                if (!response.body().isError()) {
                    //Toast.makeText(context, response.body().getSuccessMessage(), Toast.LENGTH_SHORT).show();
                    share = context.getSharedPreferences("ODTS", Context.MODE_PRIVATE);
                    SharedPreferences.Editor edit = share.edit();
                    edit.putInt("agencyId", response.body().getObjReturn().getAgencyId());
                    edit.putString("agencyName", response.body().getObjReturn().getAgencyName());
                    edit.putString("agencyAddr", response.body().getObjReturn().getAddress());
                    edit.putString(("agencyTelephone"), response.body().getObjReturn().getTelephone());
                    edit.commit();
                    Intent intent = new Intent(context, MainActivity.class);
                    context.startActivity(intent);
                    sp = context.getSharedPreferences("login", Context.MODE_PRIVATE);
                    sp.edit().putBoolean("logged", true).commit();
                }
            }

            @Override
            public void onFailure(Call<ResponseObject<Agency>> call, Throwable t) {
                Log.e("ERROR: ", t.getMessage());
            }
        });
    }
}

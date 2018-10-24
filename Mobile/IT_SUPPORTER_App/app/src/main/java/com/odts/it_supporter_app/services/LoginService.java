package com.odts.it_supporter_app.services;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.util.Log;
import android.widget.Toast;
import com.odts.it_supporter_app.activities.MainActivity;
import com.odts.it_supporter_app.apiCaller.ILoginApiCaller;
import com.odts.it_supporter_app.models.ITSupporter;
import com.odts.it_supporter_app.utils.ResponseObject;
import com.odts.it_supporter_app.utils.RetrofitInstance;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class LoginService {
    ILoginApiCaller iLoginApiCaller;
    public void checkLogin(final Context context, String username, String password, Integer roleId) {
        iLoginApiCaller = RetrofitInstance.getLoginService();
        Call<ResponseObject<ITSupporter>> call = iLoginApiCaller.checkLogin(username, password, roleId);
        call.enqueue(new Callback<ResponseObject<ITSupporter>>() {
            @Override
            public void onResponse(Call<ResponseObject<ITSupporter>> call, Response<ResponseObject<ITSupporter>> response) {
                if(!response.body().isError()){
                    //Toast.makeText(context, response.body().getSuccessMessage(), Toast.LENGTH_SHORT).show();
                    SharedPreferences share = context.getSharedPreferences("ODTS", 0);
                    SharedPreferences.Editor edit = share.edit();
                    edit.putInt("itSupporterId", response.body().getObjReturn().getItSupporterId());
                    edit.commit();
                    Intent intent = new Intent(context, MainActivity.class);
                    context.startActivity(intent);
                }
                else
                    Toast.makeText(context, response.body().getWarningMessage(), Toast.LENGTH_SHORT).show();
            }
            @Override
            public void onFailure(Call<ResponseObject<ITSupporter>> call, Throwable t) {
                Log.e("ERROR: ", t.getMessage());
            }
        });
    }
}

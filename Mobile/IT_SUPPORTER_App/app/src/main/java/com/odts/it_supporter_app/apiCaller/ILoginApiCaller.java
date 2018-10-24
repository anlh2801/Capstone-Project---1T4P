package com.odts.it_supporter_app.apiCaller;


import com.odts.it_supporter_app.models.ITSupporter;
import com.odts.it_supporter_app.utils.ResponseObject;

import retrofit2.Call;
import retrofit2.http.POST;
import retrofit2.http.Query;

public interface ILoginApiCaller {

    @POST("ITsuportter/login")
    Call<ResponseObject<ITSupporter>> checkLogin(@Query("username") String username,
                                                 @Query("password") String password,
                                                 @Query("roleId") Integer roleId);
}

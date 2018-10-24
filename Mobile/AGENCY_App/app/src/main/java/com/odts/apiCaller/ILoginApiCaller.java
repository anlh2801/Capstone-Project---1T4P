package com.odts.apiCaller;
import com.odts.models.Agency;
import com.odts.utils.ResponseObject;

import retrofit2.Call;
import retrofit2.http.POST;
import retrofit2.http.Query;

public interface ILoginApiCaller {

    @POST("agency/login")
    Call<ResponseObject<Agency>> checkLogin(@Query("username") String username,
                                            @Query("password") String password,
                                            @Query("roleId") Integer roleId);
}

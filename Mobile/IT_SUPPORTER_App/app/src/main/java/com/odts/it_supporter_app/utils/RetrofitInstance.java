package com.odts.it_supporter_app.utils;

import com.odts.it_supporter_app.services.RequestService;

import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class RetrofitInstance {

    private static Retrofit retrofit;

//private static final String BASE_URL = "http://api.myjson.com/";
private static final String BASE_URL = "http://35.197.154.50/";
    /**
     * Create an instance of Retrofit object
     * */
    public static Retrofit getRetrofitInstance() {
        if (retrofit == null) {
            retrofit = new Retrofit.Builder()
                    .baseUrl(BASE_URL)
                    .addConverterFactory(GsonConverterFactory.create())
                    .build();
        }
        return retrofit;
    }
    public static RequestService getRequestService() {
        return  getRetrofitInstance().create(RequestService.class);
    }
}
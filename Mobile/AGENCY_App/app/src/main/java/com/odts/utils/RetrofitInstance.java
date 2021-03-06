package com.odts.utils;

import com.odts.apiCaller.IITSupporterApiCaller;
import com.odts.apiCaller.ILoginApiCaller;
import com.odts.apiCaller.IRequestApiCaller;

import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class RetrofitInstance {

    private static Retrofit retrofit;

//private static final String BASE_URL = "http://api.myjson.com/";
private static final String BASE_URL = "http://35.197.154.50/";
//private static final String BASE_URL = "http://192.168.1.106:45455/";
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
    public static IRequestApiCaller getRequestService() {
        return  getRetrofitInstance().create(IRequestApiCaller.class);
    }
    public static ILoginApiCaller getLoginService() {
        return  getRetrofitInstance().create(ILoginApiCaller.class);
    }
    public static IITSupporterApiCaller getITSupporterService() {
        return  getRetrofitInstance().create(IITSupporterApiCaller.class);
    }
}
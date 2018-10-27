package com.odts.it_supporter_app.utils;

import com.odts.it_supporter_app.apiCaller.IITSupporterApiCaller;
import com.odts.it_supporter_app.apiCaller.ILoginApiCaller;

import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class RetrofitInstance {

    private static Retrofit retrofit;

//private static final String BASE_URL = "http://api.myjson.com/";
private static final String BASE_URL = "http://192.168.1.11:45455/";
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
    public static ILoginApiCaller getLoginService() {
        return  getRetrofitInstance().create(ILoginApiCaller.class);
    }
    public static IITSupporterApiCaller getITSupporterService() {
        return  getRetrofitInstance().create(IITSupporterApiCaller.class);
    }
}
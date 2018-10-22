package com.odts.activities;

import android.support.design.widget.TabLayout;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;
import android.support.v4.view.ViewPager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.Toolbar;
import android.widget.ListView;
import android.widget.Toast;

import com.odts.customTools.PendingRequestAdapter;
import com.odts.models.ListRequest;
import com.odts.services.RequestService;
import com.odts.utils.CallBackData;

import java.util.ArrayList;
import java.util.List;

public class ListRequestActivity extends AppCompatActivity {
    private Toolbar toolbar;
    private TabLayout tabLayout;
    private ViewPager viewPager;
    private RecyclerView recyclerView;
    private PendingRequestAdapter pendingRequestAdapter;
    RequestService requestService;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_list_request);
        toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        viewPager = (ViewPager) findViewById(R.id.viewpager);
        setupViewPager(viewPager);
//
        tabLayout = (TabLayout) findViewById(R.id.tabs);
        tabLayout.setupWithViewPager(viewPager);
        requestService = new RequestService();
        requestService.getRequestByStatus(ListRequestActivity.this, 3, 1, new CallBackData<ArrayList<ListRequest>>() {
            @Override
            public void onSuccess(ArrayList<ListRequest> listRequests) {
                recyclerView = (RecyclerView) findViewById(R.id.listPending);
                recyclerView.setLayoutManager(new LinearLayoutManager(ListRequestActivity.this));
                pendingRequestAdapter = new PendingRequestAdapter(getApplicationContext(), listRequests);
                recyclerView.setAdapter(pendingRequestAdapter);
            }

            @Override
            public void onFail(String message) {

            }
        });
    }

    private void setupViewPager(ViewPager viewPager) {
        ViewPagerAdapter adapter = new ViewPagerAdapter(getSupportFragmentManager());
        adapter.addFragment(new PendingFragment(), "Chờ xử lý");
        adapter.addFragment(new ProcessingFragment(), "Đang xử lý");
        viewPager.setAdapter(adapter);
    }

    class ViewPagerAdapter extends FragmentPagerAdapter {
        private final List<Fragment> mFragmentList = new ArrayList<>();
        private final List<String> mFragmentTitleList = new ArrayList<>();

        public ViewPagerAdapter(FragmentManager manager) {
            super(manager);
        }

        @Override
        public Fragment getItem(int position) {
            return mFragmentList.get(position);
        }

        @Override
        public int getCount() {
            return mFragmentList.size();
        }

        public void addFragment(Fragment fragment, String title) {
            mFragmentList.add(fragment);
            mFragmentTitleList.add(title);
        }

        @Override
        public CharSequence getPageTitle(int position) {
            return mFragmentTitleList.get(position);
        }
    }
}

window.BENCHMARK_DATA = {
  "lastUpdate": 1675735941968,
  "repoUrl": "https://github.com/virtuosgames/libplanet",
  "entries": {
    "Benchmark.Net Benchmark": [
      {
        "commit": {
          "author": {
            "email": "hong@minhee.org",
            "name": "Hong Minhee (洪 民憙)",
            "username": "dahlia"
          },
          "committer": {
            "email": "noreply@github.com",
            "name": "GitHub",
            "username": "web-flow"
          },
          "distinct": true,
          "id": "fa15924beb36a7ebe3d92052f5c20af2a235916c",
          "message": "Merge pull request #2788 from dahlia/0.48-maintenance",
          "timestamp": "2023-02-06T19:09:15+09:00",
          "tree_id": "756adedd8cd6f72fe1983dfa077c437153ef7b89",
          "url": "https://github.com/virtuosgames/libplanet/commit/fa15924beb36a7ebe3d92052f5c20af2a235916c"
        },
        "date": 1675735902458,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Libplanet.Benchmarks.BlockChain.ContainsBlock",
            "value": 109419,
            "unit": "ns",
            "range": "± 7433.213682961473"
          },
          {
            "name": "Libplanet.Benchmarks.DataModel.DataModelBenchmark.EncodeRootModel",
            "value": 4823121.953125,
            "unit": "ns",
            "range": "± 9569.304159707981"
          },
          {
            "name": "Libplanet.Benchmarks.DataModel.DataModelBenchmark.EncodeLeafModel",
            "value": 1512165.513392857,
            "unit": "ns",
            "range": "± 2957.0268583574534"
          },
          {
            "name": "Libplanet.Benchmarks.DataModel.DataModelBenchmark.EncodeRawLeafModel",
            "value": 1164695.15625,
            "unit": "ns",
            "range": "± 3737.6466835862434"
          },
          {
            "name": "Libplanet.Benchmarks.DataModel.DataModelBenchmark.DecodeRootModel",
            "value": 2639601.2239583335,
            "unit": "ns",
            "range": "± 6102.399465562137"
          },
          {
            "name": "Libplanet.Benchmarks.DataModel.DataModelBenchmark.DecodeLeafModel",
            "value": 836001.6341145834,
            "unit": "ns",
            "range": "± 1775.6153761054509"
          },
          {
            "name": "Libplanet.Benchmarks.DataModel.DataModelBenchmark.DecodeRawLeafModel",
            "value": 768488.1766183035,
            "unit": "ns",
            "range": "± 1115.3511166303313"
          },
          {
            "name": "Libplanet.Benchmarks.MineBlock.MineBlockEmpty",
            "value": 4821714.036458333,
            "unit": "ns",
            "range": "± 24722.837932529434"
          },
          {
            "name": "Libplanet.Benchmarks.MineBlock.MineBlockOneTransactionNoAction",
            "value": 5844082.352941177,
            "unit": "ns",
            "range": "± 112227.4990549003"
          },
          {
            "name": "Libplanet.Benchmarks.MineBlock.MineBlockTenTransactionsNoAction",
            "value": 26156203.333333332,
            "unit": "ns",
            "range": "± 470416.9136698495"
          },
          {
            "name": "Libplanet.Benchmarks.MineBlock.MineBlockOneTransactionWithActions",
            "value": 6070454.761904762,
            "unit": "ns",
            "range": "± 218656.30141274893"
          },
          {
            "name": "Libplanet.Benchmarks.MineBlock.MineBlockTenTransactionsWithActions",
            "value": 29521765,
            "unit": "ns",
            "range": "± 663921.0917563528"
          },
          {
            "name": "Libplanet.Benchmarks.Store.PutFirstEmptyBlock",
            "value": 106831.57894736843,
            "unit": "ns",
            "range": "± 11472.448616909869"
          },
          {
            "name": "Libplanet.Benchmarks.Store.PutFirstBlockWithTxs",
            "value": 202515.47619047618,
            "unit": "ns",
            "range": "± 11283.92068545197"
          },
          {
            "name": "Libplanet.Benchmarks.Store.PutBlockOnManyBlocks",
            "value": 191046.34146341463,
            "unit": "ns",
            "range": "± 10080.701463956764"
          },
          {
            "name": "Libplanet.Benchmarks.Store.GetOldBlockOutOfManyBlocks",
            "value": 3659157.1428571427,
            "unit": "ns",
            "range": "± 51285.05126756221"
          },
          {
            "name": "Libplanet.Benchmarks.Store.GetRecentBlockOutOfManyBlocks",
            "value": 9069593.333333334,
            "unit": "ns",
            "range": "± 104310.67926882562"
          },
          {
            "name": "Libplanet.Benchmarks.Store.TryGetNonExistentBlockHash",
            "value": 23014.736842105263,
            "unit": "ns",
            "range": "± 2828.2002555212293"
          },
          {
            "name": "Libplanet.Benchmarks.Store.PutFirstTx",
            "value": 58050,
            "unit": "ns",
            "range": "± 4571.848395650165"
          },
          {
            "name": "Libplanet.Benchmarks.Store.PutTxOnManyTxs",
            "value": 42122.58064516129,
            "unit": "ns",
            "range": "± 2514.0098332733764"
          },
          {
            "name": "Libplanet.Benchmarks.Store.GetOldTxOutOfManyTxs",
            "value": 104756.25,
            "unit": "ns",
            "range": "± 8354.57645753572"
          },
          {
            "name": "Libplanet.Benchmarks.Store.GetRecentTxOutOfManyTxs",
            "value": 6574.468085106383,
            "unit": "ns",
            "range": "± 864.3396597157765"
          },
          {
            "name": "Libplanet.Benchmarks.Store.TryGetNonExistentTxId",
            "value": 28043.75,
            "unit": "ns",
            "range": "± 2639.729352155554"
          }
        ]
      }
    ]
  }
}
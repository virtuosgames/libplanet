window.BENCHMARK_DATA = {
  "lastUpdate": 1675735587317,
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
        "date": 1675735572986,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Libplanet.Benchmarks.BlockChain.ContainsBlock",
            "value": 114511.1,
            "unit": "ns",
            "range": "± 2614.5701246748204"
          },
          {
            "name": "Libplanet.Benchmarks.DataModel.DataModelBenchmark.EncodeRootModel",
            "value": 5954943.8671875,
            "unit": "ns",
            "range": "± 32698.957509667507"
          },
          {
            "name": "Libplanet.Benchmarks.DataModel.DataModelBenchmark.EncodeLeafModel",
            "value": 1848272.0158854167,
            "unit": "ns",
            "range": "± 5300.657162056571"
          },
          {
            "name": "Libplanet.Benchmarks.DataModel.DataModelBenchmark.EncodeRawLeafModel",
            "value": 1352210.309375,
            "unit": "ns",
            "range": "± 5079.932226130775"
          },
          {
            "name": "Libplanet.Benchmarks.DataModel.DataModelBenchmark.DecodeRootModel",
            "value": 2680152.659895833,
            "unit": "ns",
            "range": "± 2592.259713574112"
          },
          {
            "name": "Libplanet.Benchmarks.DataModel.DataModelBenchmark.DecodeLeafModel",
            "value": 872451.6955729167,
            "unit": "ns",
            "range": "± 811.0272639507475"
          },
          {
            "name": "Libplanet.Benchmarks.DataModel.DataModelBenchmark.DecodeRawLeafModel",
            "value": 795854.9279436384,
            "unit": "ns",
            "range": "± 440.67114035297595"
          },
          {
            "name": "Libplanet.Benchmarks.Store.PutFirstEmptyBlock",
            "value": 111388.68085106384,
            "unit": "ns",
            "range": "± 6812.1283179069205"
          },
          {
            "name": "Libplanet.Benchmarks.Store.PutFirstBlockWithTxs",
            "value": 235394.77083333334,
            "unit": "ns",
            "range": "± 16942.387365781513"
          },
          {
            "name": "Libplanet.Benchmarks.Store.PutBlockOnManyBlocks",
            "value": 196796.26984126985,
            "unit": "ns",
            "range": "± 8980.757179814264"
          },
          {
            "name": "Libplanet.Benchmarks.Store.GetOldBlockOutOfManyBlocks",
            "value": 4074094.1333333333,
            "unit": "ns",
            "range": "± 68617.4562638678"
          },
          {
            "name": "Libplanet.Benchmarks.Store.GetRecentBlockOutOfManyBlocks",
            "value": 10042142.5,
            "unit": "ns",
            "range": "± 193395.96441842662"
          },
          {
            "name": "Libplanet.Benchmarks.Store.TryGetNonExistentBlockHash",
            "value": 23081.127659574468,
            "unit": "ns",
            "range": "± 3156.7741573166095"
          },
          {
            "name": "Libplanet.Benchmarks.Store.PutFirstTx",
            "value": 55884.36734693877,
            "unit": "ns",
            "range": "± 9018.90129705016"
          },
          {
            "name": "Libplanet.Benchmarks.Store.PutTxOnManyTxs",
            "value": 45590.02105263158,
            "unit": "ns",
            "range": "± 5328.2732342783"
          },
          {
            "name": "Libplanet.Benchmarks.Store.GetOldTxOutOfManyTxs",
            "value": 102509,
            "unit": "ns",
            "range": "± 14938.024499747487"
          },
          {
            "name": "Libplanet.Benchmarks.Store.GetRecentTxOutOfManyTxs",
            "value": 5084.085106382979,
            "unit": "ns",
            "range": "± 736.5204106198726"
          },
          {
            "name": "Libplanet.Benchmarks.Store.TryGetNonExistentTxId",
            "value": 21098.13829787234,
            "unit": "ns",
            "range": "± 2864.5165089645416"
          },
          {
            "name": "Libplanet.Benchmarks.MineBlock.MineBlockEmpty",
            "value": 5145275.691625702,
            "unit": "ns",
            "range": "± 284020.70215619815"
          },
          {
            "name": "Libplanet.Benchmarks.MineBlock.MineBlockOneTransactionNoAction",
            "value": 6254520.266666667,
            "unit": "ns",
            "range": "± 93635.9878553011"
          },
          {
            "name": "Libplanet.Benchmarks.MineBlock.MineBlockTenTransactionsNoAction",
            "value": 28443934.033333335,
            "unit": "ns",
            "range": "± 851207.3599166307"
          },
          {
            "name": "Libplanet.Benchmarks.MineBlock.MineBlockOneTransactionWithActions",
            "value": 6683389.377358491,
            "unit": "ns",
            "range": "± 275502.91396059305"
          },
          {
            "name": "Libplanet.Benchmarks.MineBlock.MineBlockTenTransactionsWithActions",
            "value": 32259434.64285714,
            "unit": "ns",
            "range": "± 544336.7515351005"
          }
        ]
      }
    ]
  }
}